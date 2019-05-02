using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain.Entities;
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

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : class, IEntity<TKey>
        {
            // TODO: VC: Actually could we get the typed repository? 
            // In case that there is specific implementation within the overridden version
            // e.g. there could be a map of keyvalue pairs for entity and key, expressed as types, then do lookup from there
            // therefore we ensure specific implementation is used, if exists, otherwise this new one

            return new EntityFrameworkRepository<TContext, TEntity, TKey>(Context);
        }
    }
}