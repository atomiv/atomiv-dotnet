using Microsoft.EntityFrameworkCore;
using Optivem.Common;

namespace Optivem.Test.EntityFrameworkCore
{
    public class DbTestClient<TContext> where TContext : DbContext
    {
        public DbTestClient(IFactory<TContext> contextFactory) 
        {
            ContextFactory = contextFactory;
        }

        public IFactory<TContext> ContextFactory { get; }

        public void EnsureDatabaseCreated()
        {
            using (var context = ContextFactory.Create())
            {
                context.Database.EnsureCreated();
            }
        }

        public void EnsureDatabaseDeleted()
        {
            using (var context = ContextFactory.Create())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
