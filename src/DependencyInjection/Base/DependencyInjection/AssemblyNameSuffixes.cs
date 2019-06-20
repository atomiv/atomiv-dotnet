using System.Collections.Generic;

namespace Optivem.DependencyInjection
{
    public static class AssemblyNameSuffixes
    {
        public static class Core
        {
            public const string Application = "Core.Application";
            public const string ApplicationInterface = "Core.ApplicationInterface";
            public const string Domain = "Core.Domain";

            public static readonly string[] All = new string[]
            {
                Application,
                ApplicationInterface,
                Domain
            };
        }

        public static class Infrastructure
        {
            public const string AspNetCore = "Infrastructure.AspNetCore";
            public const string AutoMapper = "Infrastructure.AutoMapper";
            public const string CsvHelper = "Infrastructure.CsvHelper";
            public const string EntityFrameworkCore = "Infrastructure.EntityFrameworkCore";
            public const string FluentValidation = "Infrastructure.FluentValidation";
            public const string MediatR = "Infrastructure.MediatR";
            public const string NewtonsoftJson = "Infrastructure.NewtonsoftJson";
            public const string Selenium = "Infrastructure.Selenium";
            public const string System = "Infrastructure.System";

            public static readonly string[] All = new string[]
            {
                AspNetCore,
                AutoMapper,
                CsvHelper,
                EntityFrameworkCore,
                FluentValidation,
                MediatR,
                NewtonsoftJson,
                Selenium,
                System
            };
        }

        public static readonly string[] All = Combine(new List<string[]>
        {
            Core.All,
            Infrastructure.All,
        });

        private static string[] Combine(IEnumerable<string[]> enumerables)
        {
            var combined = new List<string>();

            foreach(var enumerable in enumerables)
            {
                combined.AddRange(enumerable);
            }

            return combined.ToArray();
        }
    }
}
