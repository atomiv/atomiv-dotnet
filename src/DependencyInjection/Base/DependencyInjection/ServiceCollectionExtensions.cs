using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Optivem.DependencyInjection
{
    // TODO: VC: Strong checking that for each interface defined, that implementaiton exists, e.g. IProductService must have ProductService implementation

    public static class ServiceCollectionExtensions
    {
        // TODO: VC: Offer parameter lifetime type

        public static IServiceCollection AddScopedOpenType(this IServiceCollection services, Type openServiceType, IEnumerable<Type> implementationTypes)
        {
            var openServiceTypeName = openServiceType.Name;

            foreach(var implementationType in implementationTypes)
            {
                var serviceType = implementationType.GetTypeInfo().ImplementedInterfaces.Single(e => e.Name == openServiceTypeName);
                services.AddScoped(serviceType, implementationType);
            }

            return services;
        }

        public static IServiceCollection AddScopedMarkedTypes(this IServiceCollection services, Type markerServiceType, IEnumerable<Type> implementationTypes)
        {
            var markerServiceTypeName = markerServiceType.Name;

            foreach (var implementationType in implementationTypes)
            {
                var implementedInterfaces = implementationType.GetTypeInfo().ImplementedInterfaces;
                var serviceTypes = implementedInterfaces.Where(e => e.Name != markerServiceTypeName);

                foreach(var serviceType in serviceTypes)
                {
                    services.AddScoped(serviceType, implementationType);
                }
            }

            return services;
        }
    }
}
