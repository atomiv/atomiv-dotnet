using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Optivem.Commons.Persistence.EntityFramework
{
    public class EntityFrameworkUnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        protected readonly TContext context;

        private bool disposedValue = false;

        public EntityFrameworkUnitOfWork(TContext context)
        {
            this.context = context;
        }

        public void BeginTransaction()
        {
            context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await context.Database.BeginTransactionAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void CommitTransaction()
        {
            context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            context.Database.RollbackTransaction();
        }

        protected void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }
        
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}