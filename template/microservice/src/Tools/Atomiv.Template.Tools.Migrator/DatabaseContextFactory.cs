using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System;

namespace Atomiv.Template.Tools.Migrator
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        private const string DefaultEnvironment = "Development";
        private const string ConnectionKey = "DefaultConnection";
        private const string MigrationsAssembly = "Atomiv.Template.Tools.Migrator";

        public DatabaseContext CreateDbContext(string[] args)
        {
            var environment = GetEnvironment();

            Console.WriteLine($"The environment is {environment}.");

            var connectionString = GetConnectionString(environment);

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connectionString,
                options => options.MigrationsAssembly(MigrationsAssembly));

            return new DatabaseContext(optionsBuilder.Options);
        }

        private string GetEnvironment()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == null)
            {
                environment = DefaultEnvironment;
            }

            return environment;
        }

        private string GetConnectionString(string environment)
        {
            var configuration = GetConfigurationRoot(environment);

            var connection = configuration.GetConnectionString(ConnectionKey);

            return connection;
        }

        private IConfigurationRoot GetConfigurationRoot(string environment)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true);

            var configuration = configurationBuilder.Build();

            return configuration;
        }
    }
}
