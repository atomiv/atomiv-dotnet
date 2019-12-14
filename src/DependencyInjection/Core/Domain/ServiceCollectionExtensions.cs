using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Core.Domain
{
    public static class ServiceCollectionExtensions
    {
        private static Type RepositoryType = typeof(IRepository);
        private static Type FactoryType = typeof(IFactory);
        private static Type ServiceType = typeof(IService);

        public static IServiceCollection AddDomainCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            services.AddRepositories(types);

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
    }
}