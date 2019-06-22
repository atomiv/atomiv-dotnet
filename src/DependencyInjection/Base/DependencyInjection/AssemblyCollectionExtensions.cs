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

        // TODO: VC: DELETE

        public static Assembly[] GetCheckedAssemblies(this Assembly[] assemblies, params string[] suffixes)
        {
            if(assemblies.Any())
            {
                return assemblies;
            }

            return AssemblyCache.GetAssembliesBySuffixes( suffixes);

            /*

            // TODO: VC: Optimized
            var allAssemblies = AssemblyCache.AllAssemblies;

            var matches = new List<Assembly>();

            foreach(var suffix in assemblyNameSuffixes)
            {


                // TODO: VC: Optimize - dictionary with names, perhaps also proprocessing finding expected assemblies from framework by name
                // TODO: VC: Also enabling IModule to be overriden
                var innerMatches = allAssemblies.Where(e => e.GetName().Name.EndsWith(suffix) && !excluded.Contains(e.GetName().Name));

                matches.AddRange(innerMatches);
            }

            return matches.ToArray();
            */
        }
    }
}
