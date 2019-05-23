using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Optivem.Web.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.AspNetCore.EntityFrameworkCore
{
    public abstract class BaseTestClient<TStartup, TDbContext> : BaseTestClient<TStartup> 
        where TStartup : class
        where TDbContext : DbContext
    {
        public BaseTestClient()
        {
            var connectionStringKey = GetConnectionStringKey();
            ConnectionString = Configuration.GetConnectionString(connectionStringKey);
        }

        protected string ConnectionString { get; }

        public virtual TDbContext CreateDbContext()
        {
            var builder = CreateDbContextOptionsBuilder();

            return CreateContext(builder.Options);
        }

        protected virtual DbContextOptionsBuilder<TDbContext> CreateDbContextOptionsBuilder()
        {
            var builder = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlServer(ConnectionString);

            return builder;
        }

        protected abstract TDbContext CreateContext(DbContextOptions<TDbContext> options);

        protected virtual string GetConnectionStringKey()
        {
            return ConfigurationKeys.DefaultConnection;
        }
    }
}
