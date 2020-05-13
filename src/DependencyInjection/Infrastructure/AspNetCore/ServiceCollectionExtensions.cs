using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.DependencyInjection.Common;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using System.Reflection;

namespace Optivem.Atomiv.DependencyInjection.Infrastructure.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCoreInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            services.AddScoped<IUserContext, UserContext>();

            return services;
        }
    }
}
