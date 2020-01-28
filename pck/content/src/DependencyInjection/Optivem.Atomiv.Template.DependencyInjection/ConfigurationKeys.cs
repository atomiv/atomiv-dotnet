using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Optivem.Atomiv.Template.DependencyInjection
{
    public static class ConfigurationKeys
    {
        public const string DatabaseConnectionKey = "DefaultConnection";

        public static Action<SqlServerDbContextOptionsBuilder> SqlServerOptionsAction = b => b.MigrationsAssembly("Optivem.Atomiv.Template.Tools.Migrator");
    }
}