using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Domain;
using Atomiv.Infrastructure.System;
using System.Reflection;

namespace Atomiv.DependencyInjection.Infrastructure.System
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
