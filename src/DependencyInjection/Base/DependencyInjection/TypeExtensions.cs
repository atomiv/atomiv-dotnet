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

        public static bool ImplementsGenericInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().ImplementedInterfaces.Any(e => e.IsGenericInterface(interfaceType));
        }
        public static bool ImplementsInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().ImplementedInterfaces.Any(e => e == interfaceType);
        }

        public static bool IsConcreteImplementationOfGenericInterface(this Type type, Type interfaceType)
        {
            return type.IsConcreteClass() && type.ImplementsGenericInterface(interfaceType);
        }

        public static bool IsConcreteImplementationOfInterface(this Type type, Type interfaceType)
        {
            return type.IsConcreteClass() && type.ImplementsInterface(interfaceType);
        }

        public static bool IsChildInterface(this Type type, Type interfaceType)
        {
            return type.IsInterface && type.GetTypeInfo().IsAssignableFrom(interfaceType);
                
                // .ImplementedInterfaces.Any(e => e.GetType() == interfaceType);
        }



    }
}
