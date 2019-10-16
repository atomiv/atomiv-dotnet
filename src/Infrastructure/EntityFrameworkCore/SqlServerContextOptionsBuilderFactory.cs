using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class SqlServerContextOptionsBuilderFactory<TContext> : IFactory<DbContextOptionsBuilder<TContext>>
        where TContext : DbContext
    {
        public SqlServerContextOptionsBuilderFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public DbContextOptionsBuilder<TContext> Create()
        {
            var builder = new DbContextOptionsBuilder<TContext>()
                .UseSqlServer(ConnectionString);

            return builder;
        }
    }
}