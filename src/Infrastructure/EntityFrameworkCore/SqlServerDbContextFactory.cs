using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Optivem.Atomiv.Core.Common;
using System;

namespace Optivem.Atomiv.Infrastructure.EntityFrameworkCore
{
    public class SqlServerDbContextFactory<TDbContext> : DbContextFactory<TDbContext>, IFactory<TDbContext>
        where TDbContext : DbContext
    {
        public SqlServerDbContextFactory(string connectionString, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
            : base(CreateContextOptions(connectionString, sqlServerOptionsAction), createDbContext)
        {
        }

        private static DbContextOptions<TDbContext> CreateContextOptions(string connectionString, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction)
        {
            var contextOptionsBuilderFactory = new SqlServerContextOptionsBuilderFactory<TDbContext>(connectionString, sqlServerOptionsAction);
            var contextOptions = contextOptionsBuilderFactory.Create().Options;
            return contextOptions;
        }
    }
}