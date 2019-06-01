using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.DependencyInjection
{
    public static class TypeCollectionExtensions
    {
        public static IEnumerable<Type> GetConcreteImplementingTypes(this IEnumerable<Type> types, IEnumerable<Type> interfaceTypes)
        {
            return interfaceTypes.SelectMany(e => GetConcreteImplementingTypes(types, e));
        }
        public static IEnumerable<Type> GetConcreteImplementingTypes(this IEnumerable<Type> types, Type interfaceType)
        {
            return types.Where(f => f.IsConcreteImplementation(interfaceType));
        }
    }
}
