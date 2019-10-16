using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Framework.Test.EntityFrameworkCore
{
    public class DbTestClient<TContext> where TContext : DbContext
    {
        public DbTestClient(IFactory<TContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public IFactory<TContext> ContextFactory { get; }

        public TContext CreateContext()
        {
            return ContextFactory.Create();
        }

        public void EnsureDatabaseCreated()
        {
            using (var context = CreateContext())
            {
                // context.Database.EnsureCreated();
                context.Database.Migrate();
            }
        }

        public void EnsureDatabaseDeleted()
        {
            using (var context = ContextFactory.Create())
            {
                context.Database.EnsureDeleted();
            }
        }

        public void Add<T>(T entity) where T : class
        {
            using (var context = CreateContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : class
        {
            using (var context = CreateContext())
            {
                context.Set<T>().AddRange(entities);
                context.SaveChanges();
            }
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            using (var context = CreateContext())
            {
                context.Set<T>().RemoveRange(entities);
                context.SaveChanges();
            }
        }
    }
}