using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.DependencyInjection
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

        public static IEnumerable<Type> GetChildInterfaceTypes(this IEnumerable<Type> types, Type interfaceType)
        {
            return types.Where(e => e.IsChildInterface(interfaceType));
        }
    }
}
