using FunctionApp.Domain;
using FunctionApp.Domain.Core;
using FunctionApp.Domain.Queries;
using FunctionApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services.AddHttpClient()
                .AddLogging()
                .AddSingleton<IMyService, MyService>();
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddSingleton<IQueries, Queries>();

            services.AddTransient<Querynr1>();
            services.AddTransient<Querynr2>();

            return services;
        }
    }
}
