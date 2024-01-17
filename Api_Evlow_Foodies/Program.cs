using Api.Evlow_Foodies.Ioc.WebApi;
using auth.Helpers;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
// Configure Database connexion
builder.Services.ConfigureDBContext(configuration);

//Dependency Injection
builder.Services.ConfigureInjectionDependencyRepository();

builder.Services.ConfigureInjectionDependencyService();

// Add services to the container.
builder.Services.AddScoped<JwtService>();

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
