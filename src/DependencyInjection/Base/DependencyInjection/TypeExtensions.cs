using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection
{
    public static class TypeExtensions
    {
        public static bool IsConcreteClass(this Type type)
        {
            return type.IsClass && !type.IsAbstract;
        }

        public static bool IsGenericInterface(this Type type, Type interfaceType)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == interfaceType;
        }

        public static bool ImplementsInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().ImplementedInterfaces.Any(e => e.IsGenericInterface(interfaceType));
        }

        public static bool IsConcreteImplementation(this Type type, Type interfaceType)
        {
            return type.IsConcreteClass() && type.ImplementsInterface(interfaceType);
        }


    }
}
