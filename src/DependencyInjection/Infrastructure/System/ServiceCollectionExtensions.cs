using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Infrastructure.System;
using System.Reflection;

namespace Optivem.Atomiv.DependencyInjection.Infrastructure.System
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
