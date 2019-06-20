using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Common.Serialization;
using Optivem.Infrastructure.NewtonsoftJson;

namespace Optivem.DependencyInjection.Infrastructure.NewtonsoftJson
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNewtonsoftJsonInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJsonSerializationService, JsonSerializationService>();

            return services;
        }
    }
}
