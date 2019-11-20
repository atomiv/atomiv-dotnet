using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Optivem.Template.DependencyInjection
{
    public static class ConfigurationKeys
    {
        public const string DatabaseConnectionKey = "DefaultConnection";

        public static Action<SqlServerDbContextOptionsBuilder> SqlServerOptionsAction = b => b.MigrationsAssembly("Optivem.Template.Infrastructure.EntityFrameworkCore.Migrations");
    }
}