using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Common.Serialization;
using Optivem.Atomiv.Infrastructure.NewtonsoftJson;
using System.Reflection;

namespace Optivem.Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson
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