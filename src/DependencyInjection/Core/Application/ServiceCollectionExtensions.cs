using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Optivem.DependencyInjection.Core.Application
{
    public static class ServiceCollectionExtensions
    {
        private static Type UseCaseType = typeof(IUseCase<,>);
        private static Type ApplicationServiceType = typeof(IApplicationService);

        public static IServiceCollection AddApplicationCore(this IServiceCollection services, IEnumerable<Type> types)
        {
            services.AddUseCases(types);
            services.AddApplicationServices(types);

            return services;
        }

        public static IServiceCollection AddApplicationCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes(); ;
            return services.AddApplicationCore(types);
        }

        private static IServiceCollection AddUseCases(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(UseCaseType);
            services.AddScopedOpenType(UseCaseType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(ApplicationServiceType);
            services.AddScopedMarkedTypes(ApplicationServiceType, implementationTypes);

            return services;
        }
    }
}
