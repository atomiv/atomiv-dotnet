using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Optivem.DependencyInjection.Core.Domain
{
    public static class ServiceCollectionExtensions
    {
        private static Type IdentityFactoryType = typeof(IIdentityFactory<,>);

        public static IServiceCollection AddDomainCore(this IServiceCollection services, IEnumerable<Type> types)
        {
            services.AddIdentityFactories(types);

            return services;
        }

        public static IServiceCollection AddDomainCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes(); ;
            return services.AddDomainCore(types);
        }

        private static IServiceCollection AddIdentityFactories(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(IdentityFactoryType);
            services.AddScopedOpenType(IdentityFactoryType, implementationTypes);

            return services;
        }
    }
}
