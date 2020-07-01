using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System;
using Atomiv.Infrastructure.EntityFrameworkCore;

namespace Atomiv.Template.Tools.Migrator
{
    public class DatabaseContextFactory : DatabaseContextFactory<DatabaseContext>
    {
        private const string ConnectionKey = "DefaultConnection";
        private const string MigrationsAssembly = "Atomiv.Template.Tools.Migrator";

        protected override IConfigurationBuilder GetConfigurationBuilder(string environment)
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true);
        }

        protected override string GetConnectionString(IConfigurationRoot configuration)
        {
            return configuration.GetConnectionString(ConnectionKey);
        }

        protected override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder<DatabaseContext> optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString,
                options => options.MigrationsAssembly(MigrationsAssembly));
        }

        protected override DatabaseContext CreateDbContext(DbContextOptions<DatabaseContext> options)
        {
            return new DatabaseContext(options);
        }
    }
}
