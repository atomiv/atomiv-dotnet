using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Optivem.Template.DependencyInjection;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Migrations
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            // var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var environment = "Development";
            // throw new Exception("Environment " + environment);

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", true);

            var configuration = configurationBuilder.Build();


            // TODO: VC: Check if dependency is allowed
            var connectionKey = ConfigurationKeys.DatabaseConnectionKey;
            var connection = configuration.GetConnectionString(connectionKey);

            // throw new Exception("Connection is: " + connection);

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connection, ConfigurationKeys.SqlServerOptionsAction);

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
