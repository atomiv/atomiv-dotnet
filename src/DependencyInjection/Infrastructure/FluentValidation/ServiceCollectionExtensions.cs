using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Application;
using Atomiv.DependencyInjection.Common;
using Atomiv.Infrastructure.FluentValidation;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Atomiv.DependencyInjection.Infrastructure.FluentValidation
{
    public static class ServiceCollectionExtensions
    {
        private static Type ValidatorType = typeof(IValidator<>);
        private static Type RequestValidatorType = typeof(IRequestValidator<>);
        private static Type FluentValidationRequestValidatorType = typeof(FluentValidationRequestValidator<>);

        public static IServiceCollection AddFluentValidationInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();
            
            // Register validators first
            services.AddValidators(types);
            
            // Only register IRequestValidator<TRequest> for requests that have IValidator<TRequest>
            services.AddRequestValidators(types);

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(ValidatorType);
            services.AddScopedOpenType(ValidatorType, implementationTypes);

            return services;
        }
        
        private static IServiceCollection AddRequestValidators(this IServiceCollection services, IEnumerable<Type> types)
        {
            // Find all validator implementations (e.g., CreateProductCommandValidator : IValidator<CreateProductCommand>)
            var validatorImplementations = types.GetConcreteImplementationsOfGenericInterface(ValidatorType);
            
            // For each validator, register IRequestValidator<TRequest> -> FluentValidationRequestValidator<TRequest>
            foreach (var validatorImpl in validatorImplementations)
            {
                // Get the request type from the validator (e.g., CreateProductCommand from CreateProductCommandValidator : IValidator<CreateProductCommand>)
                var requestType = validatorImpl.BaseType?.GetGenericArguments()[0];
                if (requestType != null)
                {
                    var requestValidatorType = RequestValidatorType.MakeGenericType(requestType);
                    var fluentValidationRequestValidatorImpl = FluentValidationRequestValidatorType.MakeGenericType(requestType);
                    services.AddScoped(requestValidatorType, fluentValidationRequestValidatorImpl);
                }
            }
            
            return services;
        }
    }
}