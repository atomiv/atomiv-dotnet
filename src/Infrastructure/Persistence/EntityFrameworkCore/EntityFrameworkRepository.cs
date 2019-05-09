﻿using Microsoft.EntityFrameworkCore;
using Optivem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Persistence.EntityFrameworkCore
{
    public class EntityFrameworkRepository<TContext, TEntity, TId> : EntityFrameworkReadonlyRepository<TContext, TEntity, TId>, IRepository<TEntity, TId>
        where TContext : DbContext
        where TEntity : class, IEntity<TId>
    {
        public EntityFrameworkRepository(TContext context) : base(context)
        {
        }

        #region Create

        public void Add(TEntity entity)
        {
            set.Add(entity);
        }

        public Task AddAsync(TEntity entity)
        {
            return set.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            set.AddRange(entities);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return set.AddRangeAsync(entities);
        }

        public void AddRange(params TEntity[] entities)
        {
            set.AddRange(entities);
        }

        public Task AddRangeAsync(params TEntity[] entities)
        {
            return set.AddRangeAsync(entities);
        }

        #endregion

        #region Update

        public void Update(TEntity entity)
        {
            ExecuteUpdate(() => set.Update(entity));
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            ExecuteUpdate(() => set.UpdateRange(entities));
        }

        public void UpdateRange(params TEntity[] entities)
        {
            ExecuteUpdate(() => set.UpdateRange(entities));
        }

        private void ExecuteUpdate(Action action)
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

        #endregion

        #region Delete

        public void Delete(TEntity entity)
        {
            set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            set.RemoveRange(entities);
        }


        public void DeleteRange(params TEntity[] entities)
        {
            set.RemoveRange(entities);
        }


        #endregion
        #region Helper - Delete

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

        public void DeleteRange(IEnumerable<TId> ids)
        {
            var entities = GetEntities(ids);
            set.RemoveRange(entities);
        }

        public void DeleteRange(params TId[] ids)
        {
            var entities = GetEntities(ids);
            set.RemoveRange(entities);
        }

        #endregion

    }
}