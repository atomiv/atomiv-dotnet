using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Common.Time;
using Optivem.Framework.Infrastructure.System;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Infrastructure.System
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<IClock, SystemClock>();

            return services;
        }
    }
}
