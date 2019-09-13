using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public abstract class Repository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : ReadonlyRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, ICrudRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : class, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class, IIdentity<TId>
        where TId : IEquatable<TId>
    {
        public Repository(TContext context, params Expression<Func<TRecord, object>>[] includes) 
            : base(context, includes)
        {
            Set = context.Set<TRecord>();
        }

        protected DbSet<TRecord> Set { get; }

        #region Create

        public TIdentity Add(TAggregateRoot aggregateRoot)
        {
            var record = GetRecord(aggregateRoot);
            Set.Add(record);
            Context.SaveChanges();
            var identity = GetIdentity(record);
            return identity;
        }

        public async Task<TIdentity> AddAsync(TAggregateRoot aggregateRoot)
        {
            var record = GetRecord(aggregateRoot);
            await Set.AddAsync(record);
            await Context.SaveChangesAsync(); // TODO: VC: Check if correct here
            var identity = GetIdentity(record);
            return identity;
        }

        public void AddRange(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            Set.AddRange(records);
            Context.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            await Set.AddRangeAsync(records);
            await Context.SaveChangesAsync();
        }

        public void AddRange(params TAggregateRoot[] aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            Set.AddRange(records);
            Context.SaveChanges();
        }

        public async Task AddRangeAsync(params TAggregateRoot[] aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            await Set.AddRangeAsync(records);
            await Context.SaveChangesAsync();
        }

        #endregion Create

        #region Update

        public void Update(TAggregateRoot aggregateRoot)
        {
            var record = GetRecord(aggregateRoot);
            ExecuteConcurrentUpdate(() => Set.Update(record));
        }

        public void UpdateRange(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            ExecuteConcurrentUpdate(() => Set.UpdateRange(records));
        }

        public void UpdateRange(params TAggregateRoot[] aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            ExecuteConcurrentUpdate(() => Set.UpdateRange(records));
        }

        private void ExecuteConcurrentUpdate(Action action)
        {
            try
            {
                action();
                Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }
        }

        #endregion Update

        #region Delete

        public void Delete(TIdentity identity)
        {
            var record = GetRecord(identity);
            Set.Remove(record);
            Context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<TIdentity> identities)
        {
            var records = GetRecords(identities);
            Set.RemoveRange(records);
            Context.SaveChanges();
        }

        public void DeleteRange(params TIdentity[] identities)
        {
            var records = GetRecords(identities);
            Set.RemoveRange(records);
            Context.SaveChanges();
        }

        #endregion Delete

        #region Helper - Delete

        protected abstract TRecord GetRecord(TIdentity identity);

        protected abstract TIdentity GetIdentity(TRecord record);

        protected IEnumerable<TRecord> GetRecords(IEnumerable<TIdentity> identities)
        {
            return identities.Select(GetRecord);
        }

        #endregion Helper - Delete
    }
}