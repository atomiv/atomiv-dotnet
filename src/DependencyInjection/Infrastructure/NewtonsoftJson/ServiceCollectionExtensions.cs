using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Common.Serialization;
using Atomiv.Infrastructure.NewtonsoftJson;
using System.Reflection;

namespace Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNewtonsoftJsonInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            // NOTE: This is needed because it's referenced by the Exception handler

            services.AddSingleton<IJsonSerializer, JsonSerializer>();

            return services;
        }
    }
}