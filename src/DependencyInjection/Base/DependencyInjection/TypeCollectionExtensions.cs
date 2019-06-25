﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Framework.DependencyInjection
{
    public static class TypeCollectionExtensions
    {
        public static IEnumerable<Type> GetConcreteImplementationsOfGenericInterface(this IEnumerable<Type> types, Type interfaceType)
        {
            return types.Where(e => e.IsConcreteImplementationOfGenericInterface(interfaceType));
        }

        public static IEnumerable<Type> GetConcreteImplementationsOfInterface(this IEnumerable<Type> types, Type interfaceType)
        {
            return types.Where(e => e.IsConcreteImplementationOfInterface(interfaceType));
        }

        public static IEnumerable<Type> GetChildInterfacesOfInterface(this IEnumerable<Type> types, Type interfaceType)
        {
            return types.Where(e => e.IsChildInterfaceOfInterface(interfaceType));
        }

        public static IEnumerable<Type> GetSubclassesOfGenericClass(this IEnumerable<Type> types, Type classType)
        {
            return types.Where(e => e.IsSubclassOfGenericClass(classType));
        }

        // 
    }
}
