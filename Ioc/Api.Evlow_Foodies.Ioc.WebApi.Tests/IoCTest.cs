﻿using Api.Evlow_Foodies.Buisness.Service;
using Api.Evlow_Foodies.Buisness.Service.Contract;
using Api.Evlow_Foodies.Datas.Context.Contract;
using Api.Evlow_Foodies.Datas.Entities;
using Api.Evlow_Foodies.Datas.Repository;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Evlow_Foodies.Ioc.WebApi.Tests
{
    public static class IoCTest
    {
        /// <summary>
        /// Configuration de l'injection des repository du Web API RestFul
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureInjectionDependencyRepositoryTest(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Repositories

            services.AddScoped<IUnityRepository, UnityRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFavoriRepository, FavoriRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IPreparationRepository, PreparationRepository>();
            services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }


        /// <summary>
        /// Configure l'injection des services
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Service

            services.AddScoped<IUnityService, UnityService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IFavoriService, FavoriService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IPreparationService, PreparationService>();
            services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        /// <summary>
        /// Configuration de la connexion de la base de données
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {


            services.AddDbContext<IEvlow_FoodiesDBContext, Evlow_FoodiesDBContext>(options => options.UseInMemoryDatabase(databaseName: "TestApplication"));
            return services;
        }
    }
}