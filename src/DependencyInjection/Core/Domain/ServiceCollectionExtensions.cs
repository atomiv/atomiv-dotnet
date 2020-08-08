using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Domain;
using Atomiv.DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Atomiv.DependencyInjection.Core.Domain
{
    public static class ServiceCollectionExtensions
    {
        private static Type RepositoryType = typeof(IRepository);
        private static Type FactoryType = typeof(IFactory);
        private static Type ServiceType = typeof(IService);
        private static Type GeneratorType = typeof(IGenerator<>);
        private static Type IdentityGeneratorType = typeof(IGenerator<>);
        private static Type RuleType = typeof(IRule<>);
        private static Type ValidatableType = typeof(IValidatable);
        private static Type ValidatorInterfaceType = typeof(IValidator<>);
        private static Type ValidatorImplementationType = typeof(Validator<>);
        private static Type EnumerableValidatorInterfaceType = typeof(IEnumerableValidator<>);
        private static Type EnumerableValidatorImplementationType = typeof(EnumerableValidator<>);

        public static IServiceCollection AddDomainCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            services.AddRepositories(types);
            services.AddFactories(types);
            services.AddServices(types);
            services.AddGenerators(types);
            services.AddIdentityGenerators(types);
            services.AddRules(types);
            services.AddValidators(types);
            services.AddEnumerableValidators(types);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(RepositoryType);
            services.AddScopedMarkedTypes(RepositoryType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddFactories(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(FactoryType);
            services.AddScopedMarkedTypes(FactoryType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(ServiceType);
            services.AddScopedMarkedTypes(ServiceType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddGenerators(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(GeneratorType);
            services.AddScopedOpenType(GeneratorType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddIdentityGenerators(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(IdentityGeneratorType);
            services.AddScopedOpenType(IdentityGeneratorType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddRules(this IServiceCollection services, IEnumerable<Type> types)
        {
            var ruleImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(RuleType);

            foreach (var ruleImplementationType in ruleImplementationTypes)
            {
                var interfaceTypes = ruleImplementationType.GetTypeInfo().ImplementedInterfaces;
                var ruleInterfaceType = interfaceTypes.Single(e => e.Name == RuleType.Name);

                var objType = ruleInterfaceType.GenericTypeArguments[0];

                var ruleServiceType = RuleType.MakeGenericType(objType);

                services.AddScoped(ruleServiceType, ruleImplementationType);
            }

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(ValidatableType);

            foreach (var implementationType in implementationTypes)
            {
                var validatorServiceType = ValidatorInterfaceType.MakeGenericType(implementationType);
                var validatorImplementationType = ValidatorImplementationType.MakeGenericType(implementationType);

                services.AddScoped(validatorServiceType, validatorImplementationType);
            }

            return services;
        }

        private static IServiceCollection AddEnumerableValidators(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfInterface(ValidatableType);

            foreach (var implementationType in implementationTypes)
            {
                var validatorServiceType = EnumerableValidatorInterfaceType.MakeGenericType(implementationType);
                var validatorImplementationType = EnumerableValidatorImplementationType.MakeGenericType(implementationType);

                services.AddScoped(validatorServiceType, validatorImplementationType);
            }

            return services;
        }
    }
}