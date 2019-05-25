using Microsoft.EntityFrameworkCore;
using System;

namespace Optivem.Test.AspNetCore.EntityFrameworkCore
{
    public abstract class BaseTestClient<TStartup, TDbContext> : IDisposable
        where TStartup : class
        where TDbContext : DbContext
    {
        public BaseTestClient(string connectionStringKey, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext)
        {
            Client = WebDbTestClientFactory.Create<TStartup, TDbContext>(connectionStringKey, createDbContext);
        }

        public WebDbTestClient<TDbContext> Client { get; }

        public virtual void Dispose()
        {
            Client.Dispose();
        }
    }
}
