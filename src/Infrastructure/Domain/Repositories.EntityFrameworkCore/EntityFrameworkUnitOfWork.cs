using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Domain.Repositories.EntityFrameworkCore
{
    public class EntityFrameworkUnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private bool disposedValue = false;

        public EntityFrameworkUnitOfWork(TContext context)
        {
            this.Context = context;
        }

        protected TContext Context { get; private set; }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await Context.Database.BeginTransactionAsync();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void CommitTransaction()
        {
            Context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            Context.Database.RollbackTransaction();
        }

        protected void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                disposedValue = true;
            }
        }
        
        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EntityFrameworkRepository<TContext, T>(Context);
        }
    }
}