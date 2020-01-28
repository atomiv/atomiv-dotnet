using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Optivem.Atomiv.Template.Infrastructure.Persistence;

namespace Optivem.Atomiv.Template.Tools.Migrator
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
            var connectionKey = "DefaultConnection"; // TODO: VC:
            var connection = configuration.GetConnectionString(connectionKey);

            // TODO: VC: Perhaps make some external migrator console app?

            // throw new Exception("Connection is: " + connection);

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connection, options => options.MigrationsAssembly("Optivem.Atomiv.Template.Tools.Migrator"));

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
