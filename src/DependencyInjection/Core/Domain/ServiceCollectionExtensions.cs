using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Core.Domain
{
    public static class ServiceCollectionExtensions
    {
        private static Type IdentityFactoryType = typeof(IIdentityFactory<,>);
        private static Type RepositoryType = typeof(IRepository);

        public static IServiceCollection AddDomainCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            services.AddIdentityFactories(types);
            services.AddRepositories(types);

            return services;
        }

        private static IServiceCollection AddIdentityFactories(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(IdentityFactoryType);
            services.AddScopedOpenType(IdentityFactoryType, implementationTypes);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IEnumerable<Type> types)
        {
            // TODO: VC: Consider early detecting, and for each child interface type expect exactly ONE implementation
            // var interfaceTypes = types.GetChildInterfaceTypes(RepositoryType);

            var implementationTypes = types.GetConcreteImplementationsOfInterface(RepositoryType);
            services.AddScopedMarkedTypes(RepositoryType, implementationTypes);

            return services;
        }

    }
}
