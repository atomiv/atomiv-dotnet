using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection.Infrastructure.MediatR
{
    public static class ServiceCollectionExtensions
    {
        private static Type UseCaseType = typeof(IUseCase<,>);
        private static Type RequestValidatorType = typeof(IRequestValidator<>);
        private static Type PipelineBehaviorType = typeof(IPipelineBehavior<,>);
        private static Type MediatorRequestType = typeof(MediatorRequest<,>);
        private static Type ValidationPipelineBehaviorType = typeof(ValidationPipelineBehavior<,>);
        private static Type MediatorRequestHandlerType = typeof(MediatorRequestHandler<,>);
        private static Type MediatorRequestHandlerInterfaceType = typeof(global::MediatR.IRequestHandler<,>);

        public static IServiceCollection AddMediatRInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddScoped<IRequestHandler, MediatorRequestHandler>();

            var types = assemblies.GetTypes();
            // services.AddRequestHandlers(types); // TODO: VC: Not working properly
            services.AddValidationPipelineBehaviors(types);

            return services;
        }

        private static IServiceCollection AddRequestHandlers(this IServiceCollection services, IEnumerable<Type> types)
        {
            var useCaseImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(UseCaseType);

            foreach (var useCaseImplementationType in useCaseImplementationTypes)
            {
                var useCaseInterfaceTypes = useCaseImplementationType.GetTypeInfo().ImplementedInterfaces;
                var useCaseInterfaceType = useCaseInterfaceTypes.Single(e => e.Name == UseCaseType.Name);

                var requestType = useCaseInterfaceType.GenericTypeArguments[0];
                var responseType = useCaseInterfaceType.GenericTypeArguments[1];

                var mediatorRequestImplementationType = MediatorRequestType.MakeGenericType(requestType, responseType);
                var mediatorRequestHandlerImplementationType = MediatorRequestHandlerType.MakeGenericType(requestType, responseType);

                var serviceType = MediatorRequestHandlerInterfaceType.MakeGenericType(mediatorRequestImplementationType, responseType);

                services.AddScoped(serviceType, mediatorRequestHandlerImplementationType);

                services.AddValidationPipelineBehavior(useCaseInterfaceType);
            }

            return services;
        }

        private static IServiceCollection AddValidationPipelineBehaviors(this IServiceCollection services, IEnumerable<Type> types)
        {
            var requestValidatorImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(RequestValidatorType);

            var requestTypes = new Dictionary<string, Type>();

            foreach(var requestValidatorImplementationType in requestValidatorImplementationTypes)
            {
                var requestValidatorInterfaceTypes = requestValidatorImplementationType.GetTypeInfo().ImplementedInterfaces;
                var requestValidatorInterfaceType = requestValidatorInterfaceTypes.Single(e => e.Name == RequestValidatorType.Name);

                var requestType = requestValidatorInterfaceType.GenericTypeArguments[0];
                requestTypes.Add(requestType.Name, requestType);
            }

            var useCaseImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(UseCaseType);
            
            foreach(var useCaseImplementationType in useCaseImplementationTypes)
            {
                var useCaseInterfaceTypes = useCaseImplementationType.GetTypeInfo().ImplementedInterfaces;
                var useCaseInterfaceType = useCaseInterfaceTypes.Single(e => e.Name == UseCaseType.Name);

                var requestType = useCaseInterfaceType.GenericTypeArguments[0];

                if(!requestTypes.ContainsKey(requestType.Name))
                {
                    continue;
                }

                services.AddValidationPipelineBehavior(useCaseInterfaceType);
            }

            return services;
        }

        private static IServiceCollection AddValidationPipelineBehavior(this IServiceCollection services, Type useCaseInterfaceType)
        {
            var requestType = useCaseInterfaceType.GenericTypeArguments[0];
            var responseType = useCaseInterfaceType.GenericTypeArguments[1];

            var mediatorRequestServiceType = MediatorRequestType.MakeGenericType(requestType, responseType);
            var pipelineBehaviorServiceType = PipelineBehaviorType.MakeGenericType(mediatorRequestServiceType, responseType);
            var validationPipelineBehaviorImplementationType = ValidationPipelineBehaviorType.MakeGenericType(requestType, responseType);

            services.AddScoped(pipelineBehaviorServiceType, validationPipelineBehaviorImplementationType);

            return services;
        }
    }
}
