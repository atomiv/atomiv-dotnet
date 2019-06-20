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

        public static IServiceCollection AddDomainCore(this IServiceCollection services, params Assembly[] assemblies)
        {
            assemblies = assemblies.GetCheckedAssemblies(AssemblyNameSuffixes.Core.Domain);

            var types = assemblies.GetTypes();

            services.AddIdentityFactories(types);

            return services;
        }

        private static IServiceCollection AddIdentityFactories(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(IdentityFactoryType);
            services.AddScopedOpenType(IdentityFactoryType, implementationTypes);

            return services;
        }
    }
}
