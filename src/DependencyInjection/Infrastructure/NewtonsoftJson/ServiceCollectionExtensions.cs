using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Common.Serialization;
using Optivem.Framework.Infrastructure.NewtonsoftJson;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson
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