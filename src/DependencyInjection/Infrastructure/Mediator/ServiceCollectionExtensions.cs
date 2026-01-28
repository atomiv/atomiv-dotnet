using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Application;
using Atomiv.DependencyInjection.Common;
using Atomiv.Infrastructure.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Atomiv.DependencyInjection.Infrastructure.Mediator
{
    public static class ServiceCollectionExtensions
    {
        private static Type RequestHandlerType = typeof(IRequestHandler<,>);
        private static Type EventHandlerType = typeof(IEventHandler<>);
        private static Type RequestAuthorizerType = typeof(IRequestAuthorizer<>);
        private static Type RequestValidatorType = typeof(IRequestValidator<>);
        private static Type RequestAuthorizationHandlerType = typeof(IRequestAuthorizationHandler<>);
        private static Type RequestValidationHandlerType = typeof(IRequestValidationHandler<>);
        private static Type RequestAuthorizationHandlerImplType = typeof(RequestAuthorizationHandler<>);
        private static Type RequestValidationHandlerImplType = typeof(RequestValidationHandler<>);

        public static IServiceCollection AddSimpleMediatorInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            // Register the simple mediator as all bus interfaces
            services.AddScoped<SimpleMediator>();
            services.AddScoped<IMessageBus>(sp => sp.GetRequiredService<SimpleMediator>());
            services.AddScoped<ICommandBus>(sp => sp.GetRequiredService<SimpleMediator>());
            services.AddScoped<IQueryBus>(sp => sp.GetRequiredService<SimpleMediator>());
            services.AddScoped<IEventBus>(sp => sp.GetRequiredService<SimpleMediator>());

            // Register handlers
            var types = assemblies.GetTypes();
            services.AddRequestHandlers(types);
            services.AddEventHandlers(types);
            services.AddAuthorizationHandlers(types);
            services.AddValidationHandlers(types);

            return services;
        }

        private static IServiceCollection AddRequestHandlers(this IServiceCollection services, IEnumerable<Type> types)
        {
            var requestHandlerImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(RequestHandlerType);

            foreach (var requestHandlerImplementationType in requestHandlerImplementationTypes)
            {
                var requestHandlerInterfaceTypes = requestHandlerImplementationType.GetTypeInfo().ImplementedInterfaces;
                var requestHandlerInterfaceType = requestHandlerInterfaceTypes.Single(e => e.Name == RequestHandlerType.Name);

                services.AddScoped(requestHandlerInterfaceType, requestHandlerImplementationType);
            }

            return services;
        }

        private static IServiceCollection AddEventHandlers(this IServiceCollection services, IEnumerable<Type> types)
        {
            var eventHandlerImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(EventHandlerType);

            foreach (var eventHandlerImplementationType in eventHandlerImplementationTypes)
            {
                var eventHandlerInterfaceTypes = eventHandlerImplementationType.GetTypeInfo().ImplementedInterfaces;
                var eventHandlerInterfaceType = eventHandlerInterfaceTypes.Single(e => e.Name == EventHandlerType.Name);

                services.AddScoped(eventHandlerInterfaceType, eventHandlerImplementationType);
            }

            return services;
        }

        private static IServiceCollection AddAuthorizationHandlers(this IServiceCollection services, IEnumerable<Type> types)
        {
            // Don't automatically register RequestAuthorizationHandler<T> - let the auth infrastructure do its job
            // The mediator will try to resolve IRequestAuthorizationHandler<T> if available
            return services;
        }

        private static IServiceCollection AddValidationHandlers(this IServiceCollection services, IEnumerable<Type> types)
        {
            // Don't automatically register RequestValidationHandler<T> - let the FluentValidation infrastructure do its job
            // The mediator will try to resolve IRequestValidationHandler<T> if available
            return services;
        }
    }
}
