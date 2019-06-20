using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection
{
    public static class AssemblyCache
    {
        private static readonly Dictionary<string, List<Assembly>> FrameworkAssemblies;

        static AssemblyCache()
        {
            AllAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            FrameworkAssemblies = GetFrameworkAssemblies(AllAssemblies);
        }

        public static Assembly[] AllAssemblies { get; }

        public static Assembly[] GetAssembliesBySuffixes(params string[] suffixes)
        {
            var assemblies = new List<Assembly>();

            foreach(var suffix in suffixes)
            {
                if(FrameworkAssemblies.ContainsKey(suffix))
                {
                    var innerAssemblies = FrameworkAssemblies[suffix];
                    assemblies.AddRange(innerAssemblies);
                }
            }

            return assemblies.ToArray();
        }

        private static Dictionary<string, List<Assembly>> GetFrameworkAssemblies(Assembly[] assemblies)
        {
            var prefixes = AssemblyNamePrefixes.All;
            var suffixes = AssemblyNameSuffixes.All;

            var matches = new Dictionary<string, List<Assembly>>();

            var excluded = GetExcludedAssemblyNames(prefixes, suffixes);

            foreach(var assembly in assemblies)
            {
                var assemblyName = assembly.GetName().Name;
                var matchingSuffixes = GetMatchingSuffixes(assemblyName, suffixes, excluded);

                foreach(var matchingSuffix in matchingSuffixes)
                {
                    if (!matches.ContainsKey(matchingSuffix))
                    {
                        matches.Add(matchingSuffix, new List<Assembly>());
                    }

                    matches[matchingSuffix].Add(assembly);
                }
            }

            return matches;
        }

        private static List<string> GetMatchingSuffixes(string assemblyName, string[] suffixes, HashSet<string> excluded)
        {
            if(excluded.Contains(assemblyName))
            {
                return new List<string>();
            }

            return suffixes.Where(e => assemblyName.EndsWith(e)).ToList();
        }

        private static HashSet<string> GetExcludedAssemblyNames(IEnumerable<string> prefixes, IEnumerable<string> suffixes)
        {
            var excludedNames = new HashSet<string>();

            foreach(var prefix in prefixes)
            {
                foreach(var suffix in suffixes)
                {
                    var excludedName = $"{prefix}.{suffix}";
                    excludedNames.Add(excludedName);
                }
            }

            return excludedNames;
        }

    }
}
