using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.DependencyInjection
{
    public static class AssemblyNamePrefixes
    {
        public const string Optivem = "Optivem";
        public const string OptivemDependencyInjection = "Optivem.DependencyInjection";

        public static readonly string[] All = new string[]
        {
            Optivem,
            OptivemDependencyInjection,
        };
    }
}
