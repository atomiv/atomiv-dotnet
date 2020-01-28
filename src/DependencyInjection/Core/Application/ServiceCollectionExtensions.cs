using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Optivem.Atomiv.DependencyInjection.Core.Application
{
    public static class ServiceCollectionExtensions
    {
        // TODO: VC: DELETE use cases

        // private static Type UseCaseType = typeof(IUseCase<,>);
        private static Type ApplicationServiceType = typeof(IApplicationService);
        // private static Type ApplicationServiceAttributeType = typeof(ApplicationServiceAttribute);

        private const string ApplicationServiceSuffix = "Service";

        public static IServiceCollection AddApplicationCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            // services.AddUseCases(types);
            services.AddApplicationServices(types);

            services.AddScoped(typeof(IRequestValidationHandler<>), typeof(RequestValidationHandler<>));

            return services;
        }

        /*
        private static IServiceCollection AddUseCases(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(UseCaseType);
            services.AddScopedOpenType(UseCaseType, implementationTypes);

            return services;
        }
        */

        private static IServiceCollection AddApplicationServices(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(ApplicationServiceType);
            services.AddScopedMarkedTypes(ApplicationServiceType, implementationTypes);

            /*
            var implementationTypes = types.GetConcreteImplementationsOfInterface(ApplicationServiceType);
            services.AddScopedMarkedTypes(ApplicationServiceType, implementationTypes);
            */



            // var implementationTypes = types.GetInterfacesWithAttribute(ApplicationServiceAttributeType);
            // services.AddScopedMarkedTypes(ApplicationServiceType, implementationTypes);

            return services;
        }
    }
}