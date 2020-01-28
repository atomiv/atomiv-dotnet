﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Test.MicrosoftExtensions.Configuration;
using System;

namespace Optivem.Atomiv.Test.EntityFrameworkCore
{
    public static class DbTestClientFactory
    {
        public static DbTestClient<TDbContext> Create<TDbContext>(string connectionStringKey, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
            where TDbContext : DbContext
        {
            var configurationRoot = ConfigurationRootFactory.Create();

            var connectionString = configurationRoot.GetConnectionString(connectionStringKey);
            var databaseContextFactory = new SqlServerDbContextFactory<TDbContext>(connectionString, createDbContext, sqlServerOptionsAction);
            var databaseTestClient = new DbTestClient<TDbContext>(databaseContextFactory);
            databaseTestClient.EnsureDatabaseCreated(); // TODO: VC: Check this applies all migrations

            return databaseTestClient;
        }
    }
}