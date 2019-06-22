using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Optivem.DependencyInjection
{
    public static class AssemblyCache
    {
        private static readonly Dictionary<string, List<Assembly>> SuffixAssemblyMap;
        private static readonly Dictionary<string, List<Assembly>> NameAssemblyMap;
        private static readonly List<string> Names;

        static AssemblyCache()
        {
            AllAssemblies = GetAllAssemblies();
            NameAssemblyMap = GetNameAssemblyMap(AllAssemblies);
            Names = GetNames(NameAssemblyMap);
            SuffixAssemblyMap = GetSuffixAssemblyMap(NameAssemblyMap);
        }

        public static Assembly[] AllAssemblies { get; }

        public static Assembly[] GetAssembliesBySuffixes(params string[] suffixes)
        {
            var matches = new List<Assembly>();

            foreach(var suffix in suffixes)
            {
                if(SuffixAssemblyMap.ContainsKey(suffix))
                {
                    var innerAssemblies = SuffixAssemblyMap[suffix];
                    matches.AddRange(innerAssemblies);
                }
            }

            return matches.ToArray();
        }

        private static Assembly[] GetAllAssemblies()
        {
            var appDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            return appDomainAssemblies;
        }

        private static Dictionary<string, List<Assembly>> GetNameAssemblyMap(Assembly[] assemblies)
        {
            var nameAssemblyMap = new Dictionary<string, List<Assembly>>();

            foreach (var assembly in assemblies)
            {
                var name = assembly.GetName().Name;

                if(!nameAssemblyMap.ContainsKey(name))
                {
                    nameAssemblyMap.Add(name, new List<Assembly>());
                }

                nameAssemblyMap[name].Add(assembly);
            }

            return nameAssemblyMap;
        }

        private static List<string> GetNames(Dictionary<string, List<Assembly>> nameAssemblyMap)
        {
            var results = nameAssemblyMap.Keys.OrderBy(e => e).ToList();

            // TODO: VC: Problem is that non-used assemblies are not loaded

            foreach(var result in results)
            {
                System.Diagnostics.Trace.WriteLine(result);
            }



            return results;
        }

        private static Dictionary<string, List<Assembly>> GetSuffixAssemblyMap(Dictionary<string, List<Assembly>> nameAssemblyMap)
        {
            var prefixes = AssemblyNamePrefixes.All;
            var suffixes = AssemblyNameSuffixes.All;

            var matches = new Dictionary<string, List<Assembly>>();

            var excluded = GetExcludedAssemblyNames(prefixes, suffixes);

            foreach(var nameAssembly in nameAssemblyMap)
            {
                var assemblyName = nameAssembly.Key;
                var assemblies = nameAssembly.Value;

                var matchingSuffixes = GetMatchingSuffixes(assemblyName, suffixes, excluded);

                foreach(var matchingSuffix in matchingSuffixes)
                {
                    if (!matches.ContainsKey(matchingSuffix))
                    {
                        matches.Add(matchingSuffix, new List<Assembly>());
                    }

                    matches[matchingSuffix].AddRange(assemblies);
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
