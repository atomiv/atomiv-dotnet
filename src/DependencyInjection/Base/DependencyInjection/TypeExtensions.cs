using System;
using System.Linq;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Common
{
    public static class TypeExtensions
    {
        public static bool IsConcreteClass(this Type type)
        {
            return type.IsClass && !type.IsAbstract;
        }

        public static bool IsGenericType(this Type type, Type genericType)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == genericType;
        }

        public static bool IsGenericClass(this Type type, Type classType)
        {
            return type.IsClass && type.BaseType.GetGenericTypeDefinition() == classType;
        }

        public static bool ImplementsGenericInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().ImplementedInterfaces.Any(e => e.IsGenericType(interfaceType));
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

        public static bool IsChildInterfaceOfInterface(this Type type, Type interfaceType)
        {
            // return type.IsInterface && type.GetTypeInfo().IsSubclassOf(interfaceType);
            return type.IsInterface && type.ImplementsGenericInterface(interfaceType);
        }

        public static bool IsSubclassOfGenericClass(this Type type, Type classType)
        {
            return type.IsConcreteClass() && type.BaseType.IsGenericType(classType);
        }

        public static bool IsConcreteClassWithAttribute(this Type type, Type attributeType)
        {
            return type.IsConcreteClass() && type.HasAttribute(attributeType);
        }

        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.GetCustomAttribute(attributeType) != null;
        }
    }
}