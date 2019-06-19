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

        public static IServiceCollection AddMediatRInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddScoped<IRequestHandler, MediatorRequestHandler>();

            var types = assemblies.GetTypes();
            services.AddValidationPipelineBehaviors(types);

            /*
            services.AddMediatR(mediatRAssemblies);
            services.AddScoped<IRequestHandler, MediatorRequestHandler>();
            // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddScoped<IPipelineBehavior<MediatorRequest<CreateCustomerRequest, CreateCustomerResponse>, CreateCustomerResponse>, ValidationPipelineBehavior<CreateCustomerRequest, CreateCustomerResponse>>();
            services.AddScoped<IPipelineBehavior<MediatorRequest<UpdateCustomerRequest, UpdateCustomerResponse>, UpdateCustomerResponse>, ValidationPipelineBehavior<UpdateCustomerRequest, UpdateCustomerResponse>>();
            */

            return services;
        }

        /*
        private static IServiceCollection AddPipelineBehaviors(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(PipelineBehaviorType);
            services.AddScopedOpenType(PipelineBehaviorType, implementationTypes);

            return services;
        }
        */

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


        /*
         * 


            var useCaseImplementationType = typeof(CreateCustomerUseCase);

            var useCaseInterfaceTypes = useCaseImplementationType.GetTypeInfo().ImplementedInterfaces;
            

            var useCaseInterfaceType = useCaseInterfaceTypes.Single(e => e.Name == typeof(IUseCase<,>).Name);

            var requestType = useCaseInterfaceType.GenericTypeArguments[0];
            var responseType = useCaseInterfaceType.GenericTypeArguments[1];

            // var requestType = typeof(CreateCustomerRequest);
            // var responseType = typeof(CreateCustomerResponse);

            var mediatorRequestServiceType = mediatorRequestType.MakeGenericType(requestType, responseType);
            var pipelineBehaviorServiceType = pipelineBehaviorType.MakeGenericType(mediatorRequestServiceType, responseType);
            var validationPipelineBehaviorImplementationType = validationPipelineBehaviorType.MakeGenericType(requestType, responseType);

            services.AddScoped(pipelineBehaviorServiceType, validationPipelineBehaviorImplementationType);
         * 
         * 
         */

    }
}
