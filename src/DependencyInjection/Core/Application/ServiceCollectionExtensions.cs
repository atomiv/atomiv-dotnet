using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application.Authorization;
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
        private static Type RequestType = typeof(IRequest<>);
        private static Type RequestAuthorizerType = typeof(IRequestAuthorizer<>);
        private static Type RequestActionAuthorizerType = typeof(RequestTypeAuthorizer<,>);
        // private static Type ApplicationServiceAttributeType = typeof(ApplicationServiceAttribute);

        private const string ApplicationServiceSuffix = "Service";



        public static IServiceCollection AddApplicationCore<TRequestType>(this IServiceCollection services, params Assembly[] assemblies)
            where TRequestType : Enum
        {
            var types = assemblies.GetTypes();

            // services.AddUseCases(types);
            services.AddApplicationServices(types);
            services.AddRequestActionAuthorizers<TRequestType>(types);

            services.AddScoped(typeof(IRequestAuthorizationHandler<>), typeof(RequestAuthorizationHandler<>));
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

        private static IServiceCollection AddRequestActionAuthorizers<TRequestType>(this IServiceCollection services, IEnumerable<Type> types)
            where TRequestType : Enum
        {
            var requestTypes = types.GetConcreteImplementationsOfGenericInterface(RequestType);

            foreach(var requestType in requestTypes)
            {
                var authorizer = RequestAuthorizerType.MakeGenericType(requestType);
                var actionAuthorizer = RequestActionAuthorizerType.MakeGenericType(requestType, typeof(TRequestType));
                services.AddScoped(authorizer, actionAuthorizer);
            }

            return services;
        }
    }
}