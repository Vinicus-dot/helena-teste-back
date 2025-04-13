using Helena.Test.Back.Repository.Interfaces;
using Helena.Test.Back.Service.Implements;
using Helena.Test.Back.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Helena.Test.Back.BootstrapApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
        {
            services
             .RegisterAssemblyPublicNonGenericClasses(
                Assembly.GetAssembly(typeof(IGenericRepository)),
                Assembly.GetAssembly(typeof(IGenericService))
              )
             .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
             .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            ConnectionString connectionString = new()
            {
                HelenaDbConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_HELENA") ?? ""
            };
            services.AddSingleton<IConnectionString>(connectionString);

            return services;
        }
    }
}
