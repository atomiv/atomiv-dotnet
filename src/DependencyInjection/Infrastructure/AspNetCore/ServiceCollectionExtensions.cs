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



            return services;
        }

        public static IServiceCollection AddUserContext<TUser>(this IServiceCollection services)
            where TUser : IUser
        {
            services.AddScoped<IUserContext, UserContext<TUser>>();
            services.AddScoped<IUserContext<TUser>, UserContext<TUser>>();

            return services;
        }

        public static IServiceCollection AddUserContext<TUser, TUserFactory>(this IServiceCollection services)
            where TUser : IUser
            where TUserFactory : class, IUserFactory<TUser>
        {
            services.AddUserContext<TUser>();

            services.AddScoped<IUserFactory<TUser>, TUserFactory>();

            return services;
        }
    }
}
