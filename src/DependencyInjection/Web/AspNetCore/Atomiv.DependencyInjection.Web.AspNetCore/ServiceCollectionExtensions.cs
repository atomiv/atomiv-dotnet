using Atomiv.DependencyInjection.Common;
using Atomiv.Web.AspNetCore;
using Atomiv.Web.AspNetCore.ExceptionProblemDetailsFactories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Atomiv.DependencyInjection.Web.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCoreWeb(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            services.AddSingleton<IExceptionProblemDetailsFactory, AuthorizationExceptionProblemDetailsFactory>();
            services.AddSingleton<IExceptionProblemDetailsFactory, ExistenceExceptionProblemDetailsFactory>();
            services.AddSingleton<IExceptionProblemDetailsFactory, ValidationExceptionProblemDetailsFactory>();
            services.AddSingleton<IExceptionProblemDetailsFactory, BadHttpRequestExceptionProblemDetailsFactory>();
            services.AddSingleton<IExceptionProblemDetailsFactory, SystemExceptionProblemDetailsFactory>();

            services.AddSingleton<IRootExceptionProblemDetailsFactory, RootExceptionProblemDetailsFactory>();
            services.AddSingleton<IExceptionHandler, ExceptionHandler>();

            return services;
        }
    }
}
