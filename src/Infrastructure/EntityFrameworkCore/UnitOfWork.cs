﻿using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public abstract class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private bool disposedValue = false;

        private Dictionary<string, IRepository> _repositories;

        public UnitOfWork(TContext context, bool disposeContext = false)
        {
            Context = context;
            DisposeContext = disposeContext;
            _repositories = new Dictionary<string, IRepository>();
        }

        protected void AddRepository<TRepository>(TRepository repository) where TRepository : IRepository
        {
            var type = typeof(TRepository);
            var typeName = type.AssemblyQualifiedName;
            _repositories.Add(typeName, repository);
        }

        internal TContext Context { get; private set; }

        protected bool DisposeContext { get; private set; }

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
                    if(DisposeContext)
                    {
                        Context.Dispose();
                    }
                }

                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            var type = typeof(TRepository);
            var typeName = type.AssemblyQualifiedName;

            if(!_repositories.ContainsKey(typeName))
            {
                throw new ArgumentException($"Repository type {typeName} has not been registered");
            }

            return (TRepository)_repositories[typeName];
        }

        // TODO: VC: DELETE

        /*

        public ICrudRepository<TAggregateRoot, TIdentity> GetRepository<TAggregateRoot, TIdentity, TRecord, TId>() 
            where TAggregateRoot : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity
        {
            // TODO: VC: Actually could we get the typed repository?
            // In case that there is specific implementation within the overridden version
            // e.g. there could be a map of keyvalue pairs for entity and key, expressed as types, then do lookup from there
            // therefore we ensure specific implementation is used, if exists, otherwise this new one

            return new Repository<TContext, TAggregateRoot, TIdentity, TRecord, TId>(Context);
        }

        public IReadonlyCrudRepository<TAggregateRoot, TIdentity> GetReadonlyRepository<TAggregateRoot, TIdentity>() 
            where TAggregateRoot : IAggregateRoot<TIdentity>
            where TIdentity : IIdentity
        {
            // TODO: VC: See above
            return new ReadonlyRepository<TContext, TAggregateRoot, TIdentity>(Context);
        }

        */
    }
}