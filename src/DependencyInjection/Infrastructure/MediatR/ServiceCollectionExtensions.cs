using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.DependencyInjection.Common;
using Optivem.Atomiv.Infrastructure.MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Optivem.Atomiv.DependencyInjection.Infrastructure.MediatR
{
    public static class ServiceCollectionExtensions
    {
        private static Type RequestHandlerType = typeof(Core.Application.IRequestHandler<,>);
        private static Type RequestValidatorType = typeof(IRequestValidator<>);
        private static Type PipelineBehaviorType = typeof(IPipelineBehavior<,>);
        private static Type MediatorRequestType = typeof(MediatorRequest<>);
        private static Type ValidationPipelineBehaviorType = typeof(ValidationPipelineBehavior<,>);
        private static Type MediatorRequestHandlerType = typeof(MediatorRequestHandler<,>);
        private static Type MediatorRequestHandlerInterfaceType = typeof(global::MediatR.IRequestHandler<,>);

        public static IServiceCollection AddMediatRInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<IMessageBus, MediatorMessageBus>();

            var types = assemblies.GetTypes();
            services.AddRequestHandlers(types);
            services.AddValidationPipelineBehaviors(types);

            return services;
        }

        private static IServiceCollection AddRequestHandlers(this IServiceCollection services, IEnumerable<Type> types)
        {
            var requestHandlerImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(RequestHandlerType);

            foreach (var requestHandlerImplementationType in requestHandlerImplementationTypes)
            {
                var requestHandlerInterfaceTypes = requestHandlerImplementationType.GetTypeInfo().ImplementedInterfaces;
                var requestHandlerInterfaceType = requestHandlerInterfaceTypes.Single(e => e.Name == RequestHandlerType.Name);

                var requestType = requestHandlerInterfaceType.GenericTypeArguments[0];
                var responseType = requestHandlerInterfaceType.GenericTypeArguments[1];

                var mediatorRequestImplementationType = MediatorRequestType.MakeGenericType(responseType);
                var mediatorRequestHandlerImplementationType = MediatorRequestHandlerType.MakeGenericType(requestType, responseType);

                var serviceType = MediatorRequestHandlerInterfaceType.MakeGenericType(mediatorRequestImplementationType, responseType);

                services.AddScoped(requestHandlerInterfaceType, requestHandlerImplementationType);
                services.AddScoped(serviceType, mediatorRequestHandlerImplementationType);
            }

            return services;
        }

        private static IServiceCollection AddValidationPipelineBehaviors(this IServiceCollection services, IEnumerable<Type> types)
        {
            var requestValidatorImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(RequestValidatorType);

            var requestTypes = new Dictionary<string, Type>();

            foreach (var requestValidatorImplementationType in requestValidatorImplementationTypes)
            {
                var requestValidatorInterfaceTypes = requestValidatorImplementationType.GetTypeInfo().ImplementedInterfaces;
                var requestValidatorInterfaceType = requestValidatorInterfaceTypes.Single(e => e.Name == RequestValidatorType.Name);

                var requestType = requestValidatorInterfaceType.GenericTypeArguments[0];
                requestTypes.Add(requestType.Name, requestType);
            }

            var requestHandlerImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(RequestHandlerType);

            foreach (var requestHandlerImplementationType in requestHandlerImplementationTypes)
            {
                var requestHandlerInterfaceTypes = requestHandlerImplementationType.GetTypeInfo().ImplementedInterfaces;
                var requestHandlerInterfaceType = requestHandlerInterfaceTypes.Single(e => e.Name == RequestHandlerType.Name);

                var requestType = requestHandlerInterfaceType.GenericTypeArguments[0];

                if (!requestTypes.ContainsKey(requestType.Name))
                {
                    continue;
                }

                services.AddValidationPipelineBehavior(requestHandlerInterfaceType);
            }

            return services;
        }

        private static IServiceCollection AddValidationPipelineBehavior(this IServiceCollection services, Type requestHandlerInterfaceType)
        {
            var requestType = requestHandlerInterfaceType.GenericTypeArguments[0];
            var responseType = requestHandlerInterfaceType.GenericTypeArguments[1];

            var mediatorRequestServiceType = MediatorRequestType.MakeGenericType(responseType);
            var pipelineBehaviorServiceType = PipelineBehaviorType.MakeGenericType(mediatorRequestServiceType, responseType);
            var validationPipelineBehaviorImplementationType = ValidationPipelineBehaviorType.MakeGenericType(requestType, responseType);

            services.AddScoped(pipelineBehaviorServiceType, validationPipelineBehaviorImplementationType);

            return services;
        }
    }
}