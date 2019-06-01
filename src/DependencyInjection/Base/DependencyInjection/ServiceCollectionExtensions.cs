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
        public static IServiceCollection AddTransient(this IServiceCollection services, Type openServiceType, IEnumerable<Type> implementationTypes)
        {
            var openServiceTypeName = openServiceType.Name;

            foreach(var implementationType in implementationTypes)
            {
                var serviceType = implementationType.GetTypeInfo().ImplementedInterfaces.Single(e => e.Name == openServiceTypeName);
                services.AddTransient(serviceType, implementationType);
            }

            return services;
        }
    }
}
