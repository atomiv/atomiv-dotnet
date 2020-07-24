using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Domain;
using Atomiv.DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Atomiv.DependencyInjection.Core.Domain
{
    public static class ServiceCollectionExtensions
    {
        private static Type RepositoryType = typeof(IRepository);
        private static Type FactoryType = typeof(IFactory);
        private static Type ServiceType = typeof(IService);
        private static Type GeneratorType = typeof(IGenerator<>);
        private static Type IdentityGeneratorType = typeof(IGenerator<>);

        public static IServiceCollection AddDomainCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            services.AddRepositories(types);
            services.AddFactories(types);
            services.AddServices(types);
            services.AddGenerators(types);
            services.AddIdentityGenerators(types);

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
    }
}