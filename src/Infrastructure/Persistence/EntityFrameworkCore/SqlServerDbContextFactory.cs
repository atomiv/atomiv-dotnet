using Microsoft.EntityFrameworkCore;
using Optivem.Common;
using System;

namespace Optivem.Infrastructure.Persistence.EntityFrameworkCore
{
    public class SqlServerDbContextFactory<TDbContext> : DbContextFactory<TDbContext>, IFactory<TDbContext>
        where TDbContext : DbContext
    {
        public SqlServerDbContextFactory(string connectionString, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext) 
            : base(CreateContextOptions(connectionString), createDbContext)
        {
        }

        private static DbContextOptions<TDbContext> CreateContextOptions(string connectionString)
        {
            var contextOptionsBuilderFactory = new SqlServerContextOptionsBuilderFactory<TDbContext>(connectionString);
            var contextOptions = contextOptionsBuilderFactory.Create().Options;
            return contextOptions;
        }
    }
}
