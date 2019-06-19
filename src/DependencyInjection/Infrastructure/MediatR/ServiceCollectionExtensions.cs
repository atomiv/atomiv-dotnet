using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection.Infrastructure.MediatR
{
    public static class ServiceCollectionExtensions
    {
        private static Type PipelineBehaviorType = typeof(IPipelineBehavior<,>);

        public static IServiceCollection AddMediatRInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddScoped<IRequestHandler, MediatorRequestHandler>();

            var types = assemblies.GetTypes();
            services.AddPipelineBehaviors(types);

            /*
            services.AddMediatR(mediatRAssemblies);
            services.AddScoped<IRequestHandler, MediatorRequestHandler>();
            // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddScoped<IPipelineBehavior<MediatorRequest<CreateCustomerRequest, CreateCustomerResponse>, CreateCustomerResponse>, ValidationPipelineBehavior<CreateCustomerRequest, CreateCustomerResponse>>();
            services.AddScoped<IPipelineBehavior<MediatorRequest<UpdateCustomerRequest, UpdateCustomerResponse>, UpdateCustomerResponse>, ValidationPipelineBehavior<UpdateCustomerRequest, UpdateCustomerResponse>>();
            */

            return services;
        }
        private static IServiceCollection AddPipelineBehaviors(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(PipelineBehaviorType);
            services.AddScopedOpenType(PipelineBehaviorType, implementationTypes);

            return services;
        }
    }
}
