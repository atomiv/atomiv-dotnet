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
            services.AddScoped<IJsonSerializer, JsonSerializer>();

            return services;
        }
    }
}