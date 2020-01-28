using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Optivem.Atomiv.Core.Common;
using System;

namespace Optivem.Atomiv.Infrastructure.EntityFrameworkCore
{
    public class SqlServerContextOptionsBuilderFactory<TContext> : IFactory<DbContextOptionsBuilder<TContext>>
        where TContext : DbContext
    {
        public SqlServerContextOptionsBuilderFactory(string connectionString, Action<SqlServerDbContextOptionsBuilder> sqlServerOptionsAction = null)
        {
            ConnectionString = connectionString;
            SqlServerOptionsAction = sqlServerOptionsAction;
        }

        public string ConnectionString { get; }

        public Action<SqlServerDbContextOptionsBuilder> SqlServerOptionsAction { get; }

        public DbContextOptionsBuilder<TContext> Create()
        {
            // TODO: VC: Remove the migrations from here

            var builder = new DbContextOptionsBuilder<TContext>()
                .UseSqlServer(ConnectionString, SqlServerOptionsAction);

            return builder;
        }
    }
}