using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Common.Serialization;
using Optivem.Infrastructure.NewtonsoftJson;
using System.Reflection;

namespace Optivem.DependencyInjection.Infrastructure.NewtonsoftJson
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNewtonsoftJsonInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<IJsonSerializationService, JsonSerializationService>();

            return services;
        }
    }
}
