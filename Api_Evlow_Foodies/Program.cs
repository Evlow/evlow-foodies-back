using Api.Evlow_Foodies.Common;
using Api.Evlow_Foodies.Ioc.WebApi;
using Api.Evlow_Foodies.Ioc.WebApi.Tests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
// Configure Database connexion

builder.Services.Configure<JwtSetting>(configuration.GetSection("JwtSettings"));

if (builder.Environment.IsEnvironment("Test"))
{
    // Configure Database connexion
    builder.Services.ConfigureDBContextTest();

    //Dependency Injection
    builder.Services.ConfigureInjectionDependencyRepositoryTest();

    builder.Services.ConfigureInjectionDependencyServiceTest();
}
else
{
    // Configure Database connexion
    builder.Services.ConfigureDBContext(configuration);

    builder.Services.ConfigureIdentity();

    //Dependency Injection
    builder.Services.ConfigureInjectionDependencyRepository();

    builder.Services.ConfigureInjectionDependencyService();
}

// Système de Validation d'un token
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSetting>();
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        ClockSkew = TimeSpan.Zero
    };
});

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Configure HTTPS redirection with the HTTPS port
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443; // Specify your HTTPS port here
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("_myAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }