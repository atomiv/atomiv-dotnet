using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Application;
using Atomiv.DependencyInjection.Common;
using Atomiv.Infrastructure.AspNetCore;
using System;
using System.Reflection;

namespace Atomiv.DependencyInjection.Infrastructure.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCoreInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            return services;
        }

        public static IServiceCollection AddApplicationUserContext<TApplicationUser, TRequestType, TApplicationUserSerializer, TIApplicationUserContext, TApplicationUserContext>(this IServiceCollection services)
            where TApplicationUser : IApplicationUser<TRequestType>
            where TRequestType : Enum
            where TApplicationUserSerializer : class, IApplicationUserSerializer<TApplicationUser, TRequestType>
            where TIApplicationUserContext : class, IApplicationUserContext<TApplicationUser, TRequestType>
            where TApplicationUserContext : class, IApplicationUserContext<TApplicationUser, TRequestType>, TIApplicationUserContext
        {
            services.AddApplicationUserContext<TApplicationUser, TRequestType, TIApplicationUserContext, TApplicationUserContext>();

            services.AddScoped<IApplicationUserSerializer<TApplicationUser, TRequestType>, TApplicationUserSerializer>();

            return services;
        }

        private static IServiceCollection AddApplicationUserContext<TApplicationUser, TRequestType, TIApplicationUserContext, TApplicationUserContext>(this IServiceCollection services)
            where TApplicationUser : IApplicationUser<TRequestType>
            where TRequestType : Enum
            where TIApplicationUserContext : class, IApplicationUserContext<TApplicationUser, TRequestType>
            where TApplicationUserContext : class, IApplicationUserContext<TApplicationUser, TRequestType>, TIApplicationUserContext
        {
            services.AddScoped<IApplicationUserContext<TRequestType>, ApplicationUserContext<TApplicationUser, TRequestType>>();
            services.AddScoped<IApplicationUserContext<TApplicationUser, TRequestType>, ApplicationUserContext<TApplicationUser, TRequestType>>();

            services.AddScoped<TIApplicationUserContext, TApplicationUserContext>();

            return services;
        }
    }
}
