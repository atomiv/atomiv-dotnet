using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Optivem.DependencyInjection
{
    public static class AssemblyCollectionExtensions
    {
        public static IEnumerable<Type> GetTypes(this IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(e => e.GetTypes());
        }
    }
}
