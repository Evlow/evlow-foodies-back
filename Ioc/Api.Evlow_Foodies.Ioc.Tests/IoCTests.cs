using Api.Evlow_Foodies.Datas.Entities;
using Api.Evlow_Foodies.Datas.Context.Contract;
using Api.Evlow_Foodies.Ioc.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Evlow_Foodies.Ioc.Tests
{
    public static class IoCTests
    {
        /// <summary>
        /// Configuration de l'injection des repository du Web API RestFul
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureInjectionDependencyRepositoryTest(this IServiceCollection services)
        {
            services.ConfigureInjectionDependencyRepository();

            return services;

        }


        /// <summary>
        /// Configure l'injection des services
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services)
        {
            services.ConfigureInjectionDependencyService();

            return services;
        }


        /// <summary>
        /// Configuration de la connexion de la base de données en mémoire pour l'environnement de test
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            services.AddDbContext<IEvlow_FoodiesDBContext, Evlow_Foodies_SimplonDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));

            return services;
        }
    }
}