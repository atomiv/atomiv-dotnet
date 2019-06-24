using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Optivem.Test.AspNetCore.EntityFrameworkCore
{
    // TODO: VC: DELETE

    /*
    public abstract class BaseTestClient<TStartup, TDbContext> : IDisposable
        where TStartup : class
        where TDbContext : DbContext
    {
        public BaseTestClient(string connectionStringKey, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext)
        {
            Client = WebDbTestClientFactory.Create<TStartup, TDbContext>(connectionStringKey, createDbContext);
        }

        public WebDbTestClient<TDbContext> Client { get; }

        public void Add<T>(T entity) where T : class
        {
            Client.DatabaseTestClient.Add(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            Client.DatabaseTestClient.AddRange(entities);
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            Client.DatabaseTestClient.RemoveRange(entities);
        }

        public virtual void Dispose()
        {
            Client.Dispose();
        }
    }

    */
}
