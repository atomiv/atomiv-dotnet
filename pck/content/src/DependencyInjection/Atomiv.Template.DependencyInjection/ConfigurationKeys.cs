using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Atomiv.Template.DependencyInjection
{
    public static class ConfigurationKeys
    {
        public const string DatabaseConnectionKey = "DefaultConnection";

        public const string DbSettings = "DbSettings";

        public static Action<SqlServerDbContextOptionsBuilder> SqlServerOptionsAction = b => b.MigrationsAssembly("Atomiv.Template.Tools.Migrator");
    }
}