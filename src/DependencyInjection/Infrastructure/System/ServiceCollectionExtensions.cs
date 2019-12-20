using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.System;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Infrastructure.System
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<ITimeService, SystemTimeService>();

            return services;
        }
    }
}
