using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Test.MicrosoftExtensions.Configuration;
using System;

namespace Optivem.Framework.Test.EntityFrameworkCore
{
    public static class DbTestClientFactory
    {
        public static DbTestClient<TDbContext> Create<TDbContext>(string connectionStringKey, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext)
            where TDbContext : DbContext
        {
            var configurationRoot = ConfigurationRootFactory.Create();

            var connectionString = configurationRoot.GetConnectionString(connectionStringKey);
            var databaseContextFactory = new SqlServerDbContextFactory<TDbContext>(connectionString, createDbContext);
            var databaseTestClient = new DbTestClient<TDbContext>(databaseContextFactory);
            databaseTestClient.EnsureDatabaseCreated(); // TODO: VC: Check this applies all migrations

            return databaseTestClient;
        }
    }
}
