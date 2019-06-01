using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransientOpenType(this IServiceCollection services, Type openServiceType, IEnumerable<Type> implementationTypes)
        {
            var openServiceTypeName = openServiceType.Name;

            foreach(var implementationType in implementationTypes)
            {
                var serviceType = implementationType.GetTypeInfo().ImplementedInterfaces.Single(e => e.Name == openServiceTypeName);
                services.AddTransient(serviceType, implementationType);
            }

            return services;
        }

        public static IServiceCollection AddTransientMarkedTypes(this IServiceCollection services, Type markerServiceType, IEnumerable<Type> implementationTypes)
        {
            var markerServiceTypeName = markerServiceType.Name;

            foreach (var implementationType in implementationTypes)
            {
                var implementedInterfaces = implementationType.GetTypeInfo().ImplementedInterfaces;
                var serviceTypes = implementedInterfaces.Where(e => e.Name != markerServiceTypeName);

                foreach(var serviceType in serviceTypes)
                {
                    services.AddTransient(serviceType, implementationType);
                }
            }

            return services;
        }
    }
}
