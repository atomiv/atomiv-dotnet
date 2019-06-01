using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Optivem.Infrastructure.EntityFrameworkCore;
using Optivem.Test.Common.Configuration;
using Optivem.Test.EntityFrameworkCore;
using System;

namespace Optivem.Test.AspNetCore.EntityFrameworkCore
{
    public static class WebDbTestClientFactory
    {
        public static WebDbTestClient<TDbContext> Create<TStartup, TDbContext>(string connectionStringKey, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext)
            where TStartup : class
            where TDbContext : DbContext
        {
            var configurationRoot = ConfigurationRootFactory.Create();

            var connectionString = configurationRoot.GetConnectionString(connectionStringKey);
            var databaseContextFactory = new SqlServerDbContextFactory<TDbContext>(connectionString, createDbContext);
            var databaseTestClient = new DbTestClient<TDbContext>(databaseContextFactory);
            databaseTestClient.EnsureDatabaseCreated(); // TODO: VC: Check this applies all migrations

            var webTestClient = WebTestClientFactory.Create<TStartup>(configurationRoot);

            return new WebDbTestClient<TDbContext>(configurationRoot, webTestClient, databaseTestClient);
        }


    }
}
