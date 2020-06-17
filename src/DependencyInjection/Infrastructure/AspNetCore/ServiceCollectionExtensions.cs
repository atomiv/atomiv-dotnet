using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.DependencyInjection.Common;
using Optivem.Atomiv.Infrastructure.AspNetCore;
using System;
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

        public static IServiceCollection AddUserContext<TUser, TRequestType>(this IServiceCollection services)
            where TUser : IApplicationUser<TRequestType>
            where TRequestType : Enum
        {
            services.AddScoped<IApplicationUserContext<TRequestType>, UserContext<TUser, TRequestType>>();
            services.AddScoped<IApplicationUserContext<TUser, TRequestType>, UserContext<TUser, TRequestType>>();

            return services;
        }

        public static IServiceCollection AddUserContext<TUser, TRequestType, TUserFactory>(this IServiceCollection services)
            where TUser : IApplicationUser<TRequestType>
            where TRequestType : Enum
            where TUserFactory : class, IApplicationUserSerializer<TUser, TRequestType>
        {
            services.AddUserContext<TUser, TRequestType>();

            services.AddScoped<IApplicationUserSerializer<TUser, TRequestType>, TUserFactory>();

            return services;
        }
    }
}
