using Microsoft.EntityFrameworkCore;
using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Persistence.EntityFrameworkCore
{
    public abstract class Repository<TContext, TAggregateRoot, TIdentity, TRecord, TId> : ReadonlyRepository<TContext, TAggregateRoot, TIdentity, TRecord, TId>, ICrudRepository<TAggregateRoot, TIdentity>
        where TContext : DbContext
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
        where TRecord : class
    {
        public Repository(TContext context) : base(context)
        {
        }

        #region Create

        public TIdentity Add(TAggregateRoot aggregateRoot)
        {
            var record = GetRecord(aggregateRoot);
            set.Add(record);
            context.SaveChanges(); // TODO: VC: Check if correct here
            var identity = GetIdentity(record);
            return identity;
        }

        public async Task<TIdentity> AddAsync(TAggregateRoot aggregateRoot)
        {
            var record = GetRecord(aggregateRoot);
            await set.AddAsync(record);
            await context.SaveChangesAsync(); // TODO: VC: Check if correct here
            var identity = GetIdentity(record);
            return identity;
        }

        public void AddRange(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            set.AddRange(records);
        }

        public Task AddRangeAsync(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            return set.AddRangeAsync(records);
        }

        public void AddRange(params TAggregateRoot[] aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            set.AddRange(records);
        }

        public Task AddRangeAsync(params TAggregateRoot[] aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            return set.AddRangeAsync(records);
        }

        #endregion Create

        #region Update

        public void Update(TAggregateRoot aggregateRoot)
        {
            var record = GetRecord(aggregateRoot);
            ExecuteConcurrentUpdate(() => set.Update(record));
        }

        public void UpdateRange(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            ExecuteConcurrentUpdate(() => set.UpdateRange(records));
        }

        public void UpdateRange(params TAggregateRoot[] aggregateRoots)
        {
            var records = GetRecords(aggregateRoots);
            ExecuteConcurrentUpdate(() => set.UpdateRange(records));
        }

        private void ExecuteConcurrentUpdate(Action action)
        {
            try
            {
                action();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }
        }

        #endregion Update

        #region Delete

        // TODO: VC: DELETE

        /*

        public void Delete(TAggregateRoot aggregateRoot)
        {
            set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TAggregateRoot> entities)
        {
            set.RemoveRange(entities);
        }

        public void DeleteRange(params TAggregateRoot[] entities)
        {
            set.RemoveRange(entities);
        }

    */

        // TODO: VC: Should be named DELETE

        public void Delete(TIdentity identity)
        {
            var record = GetRecord(identity);
            set.Remove(record);
        }

        public void DeleteRange(IEnumerable<TIdentity> identities)
        {
            var records = GetRecords(identities);
            set.RemoveRange(records);
        }



        public void DeleteRange(params TIdentity[] identities)
        {
            var records = GetRecords(identities);
            set.RemoveRange(records);
        }

        #endregion Delete

        #region Helper - Delete

        // TODO: VC: DELETE

        /*

        protected void DeleteInner(object[] id)
        {
            var entity = GetSingleOrDefaultInner(id);

            if (entity == null)
            {
                return;
            }

            Delete(entity);
        }

        protected void DeleteRangeInner(IEnumerable<object[]> ids)
        {
            var entities = GetEntities(ids);

            DeleteRange(entities);
        }

        protected void DeleteRangeInner(params object[][] ids)
        {
            var entities = GetEntities(ids);

            DeleteRange(entities);
        }

        */

        protected abstract TRecord GetRecord(TIdentity identity);

        protected abstract TIdentity GetIdentity(TRecord record);

        protected IEnumerable<TRecord> GetRecords(IEnumerable<TIdentity> identities)
        {
            return identities.Select(GetRecord);
        }

        #endregion Helper - Delete
    }
}