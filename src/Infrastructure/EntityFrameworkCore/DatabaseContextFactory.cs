using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Infrastructure.EntityFrameworkCore
{
    public abstract class DatabaseContextFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : DbContext
    {
        private const string DefaultEnvironment = "Development";

        public TDbContext CreateDbContext(string[] args)
        {
            var environment = GetEnvironment();

            Console.WriteLine($"The environment is {environment}.");

            var configurationBuilder = GetConfigurationBuilder(environment);
            var configuration = configurationBuilder.Build();

            var connectionString = GetConnectionString(configuration);

            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            ConfigureDbContextOptionsBuilder(optionsBuilder, connectionString);

            var options = optionsBuilder.Options;

            return CreateDbContext(options);
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



        protected abstract TDbContext CreateDbContext(DbContextOptions<TDbContext> options);

        protected abstract IConfigurationBuilder GetConfigurationBuilder(string environment);

        protected abstract string GetConnectionString(IConfigurationRoot configuration);

        protected virtual void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder<TDbContext> optionsBuilder, string connectionString)
        {
            // NOTE: No code here, can be specified in subclasses
        }
    }
}
