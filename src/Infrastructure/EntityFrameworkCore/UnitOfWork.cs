using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atomiv.Core.Application;

namespace Atomiv.Infrastructure.EntityFrameworkCore
{
    public abstract class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private IDbContextTransaction _dbContextTransaction;

        private bool disposedValue = false;

        public UnitOfWork(TContext context, bool disposeContext = false)
        {
            Context = context;
            DisposeContext = disposeContext;
        }

        internal TContext Context { get; private set; }

        protected bool DisposeContext { get; private set; }

        public async Task BeginAsync()
        {
            if (_dbContextTransaction != null)
            {
                throw new InvalidOperationException("Cannot begin transaction because it was already started");
            }

            _dbContextTransaction = await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                if (_dbContextTransaction == null)
                {
                    await Context.SaveChangesAsync();
                    return;

                    // throw new InvalidOperationException("Cannot commit transaction because it was not started");
                }

                try
                {
                    Context.Database.CommitTransaction();
                }
                catch (Exception)
                {
                    Context.Database.RollbackTransaction();
                    throw;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }
        }

        protected void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if(_dbContextTransaction != null)
                    {
                        _dbContextTransaction.Dispose();
                    }

                    if (DisposeContext)
                    {
                        Context.Dispose();
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}