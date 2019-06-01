using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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

        private static IServiceCollection AddUseCases(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(UseCaseType);
            services.AddTransientOpenType(UseCaseType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(ApplicationServiceType);
            services.AddTransientMarkedTypes(ApplicationServiceType, implementationTypes);

            return services;
        }
    }
}
