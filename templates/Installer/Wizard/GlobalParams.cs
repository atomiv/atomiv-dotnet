using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Installer.Wizard
{
    public static class GlobalParams
    {
        private static Dictionary<string, string> Map = new Dictionary<string, string>();

        public static void Add(string paramName, string paramValue)
        {
            Map.Add(paramName, paramValue);
        }

        public static void AddAllFrom(Dictionary<string, string> other)
        {
            foreach (var entry in other)
            {
                Add(entry.Key, entry.Value);
            }
        }

        public static string GetValue(string paramName)
        {
            return Map[paramName];
        }

        public static void AddAllTo(Dictionary<string, string> other)
        {
            foreach (var entry in Map)
            {
                other.Add(entry.Key, entry.Value);
            }
        }
    }
}
