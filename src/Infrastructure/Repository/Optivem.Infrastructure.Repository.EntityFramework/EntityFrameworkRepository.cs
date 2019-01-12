using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Commons.Persistence.EntityFramework
{
    public class EntityFrameworkRepository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext context;
        protected readonly DbSet<TEntity> set;

        public EntityFrameworkRepository(TContext context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
        }

        #region Read

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, orderBy, skip, take, includes);
            return query.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, orderBy, skip, take, includes);
            return await query.ToListAsync();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.Single();
        }

        public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.SingleAsync();
        }

        public TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.SingleOrDefault();
        }

        public Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.SingleOrDefaultAsync();
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.First();
        }

        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.FirstAsync();
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.FirstOrDefault();
        }

        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = GetQuery(filter, includes);
            return query.FirstOrDefaultAsync();
        }

        public long GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = GetQuery(filter);
            return query.LongCount();
        }

        public Task<long> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = GetQuery(filter);
            return query.LongCountAsync();
        }

        public bool GetExists(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = GetQuery(filter);
            return query.Any();
        }

        public Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = GetQuery(filter);
            return query.AnyAsync();
        }

        #endregion

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
            set.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            set.UpdateRange(entities);
        }

        public void UpdateRange(params TEntity[] entities)
        {
            set.UpdateRange(entities);
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

        #region Helper

        protected IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = set.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        protected IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            return GetQuery(filter, null, null, null, includes);
        }

        protected IEnumerable<TEntity> GetEntities<T>(IEnumerable<T> ids)
        {
            var entities = new List<TEntity>();

            foreach (var id in ids)
            {
                var entity = GetSingleOrDefaultInner(id);

                if (entity != null)
                {
                    entities.Add(entity);
                }
            }

            return entities;
        }

        protected TEntity GetSingleOrDefaultInner(params object[] id)
        {
            return set.Find(id);
        }

        protected Task<TEntity> GetSingleOrDefaultInnerAsync(params object[] id)
        {
            return set.FindAsync(id);
        }

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

        #endregion
    }

    public class EntityFrameworkRepository<TContext, TEntity, TKey> : EntityFrameworkRepository<TContext, TEntity>, IRepository<TEntity, TKey>
        where TContext : DbContext
        where TEntity : class
    {
        public EntityFrameworkRepository(TContext context) 
            : base(context)
        {
        }

        #region Read

        public TEntity GetSingleOrDefault(TKey id)
        {
            return GetSingleOrDefaultInner(id);
        }

        public Task<TEntity> GetSingleOrDefaultAsync(TKey id)
        {
            return GetSingleOrDefaultInnerAsync(id);
        }

        public bool GetExists(TKey id)
        {
            var entity = GetSingleOrDefault(id);
            return entity != null;
        }

        public async Task<bool> GetExistsAsync(TKey id)
        {
            var entity = await GetSingleOrDefaultAsync(id);
            return entity != null;
        }

        #endregion

        #region Delete

        public void DeleteRange(IEnumerable<TKey> ids)
        {
            var entities = GetEntities(ids);
            set.RemoveRange(entities);
        }

        public void DeleteRange(params TKey[] ids)
        {
            var entities = GetEntities(ids);
            set.RemoveRange(entities);
        }

        #endregion
    }

    public class EntityFrameworkRepository<TContext, TEntity, TKey1, TKey2> : EntityFrameworkRepository<TContext, TEntity>, IRepository<TEntity, TKey1, TKey2>
        where TContext : DbContext
        where TEntity : class
    {
        public EntityFrameworkRepository(TContext context)
            : base(context)
        {
        }

        #region Read

        public TEntity GetSingleOrDefault(TKey1 id1, TKey2 id2)
        {
            return GetSingleOrDefaultInner(id1, id2);
        }

        public TEntity GetSingleOrDefault(Tuple<TKey1, TKey2> id)
        {
            return GetSingleOrDefault(id.Item1, id.Item2);
        }

        public Task<TEntity> GetSingleOrDefaultAsync(TKey1 id1, TKey2 id2)
        {
            return GetSingleOrDefaultInnerAsync(id1, id2);
        }

        public Task<TEntity> GetSingleOrDefaultAsync(Tuple<TKey1, TKey2> id)
        {
            return GetSingleOrDefaultAsync(id.Item1, id.Item2);
        }

        public bool GetExists(TKey1 id1, TKey2 id2)
        {
            var entity = GetSingleOrDefault(id1, id2);
            return entity != null;
        }

        public bool GetExists(Tuple<TKey1, TKey2> id)
        {
            return GetExists(id.Item1, id.Item2);
        }

        public async Task<bool> GetExistsAsync(TKey1 id1, TKey2 id2)
        {
            var entity = await GetSingleOrDefaultAsync(id1, id2);
            return entity != null;
        }

        public Task<bool> GetExistsAsync(Tuple<TKey1, TKey2> id)
        {
            return GetExistsAsync(id.Item1, id.Item2);
        }

        #endregion

        #region Delete

        public void DeleteRange(IEnumerable<Tuple<TKey1, TKey2>> ids)
        {
            var entities = GetEntities(ids);
            set.RemoveRange(entities);
        }

        public void DeleteRange(params Tuple<TKey1, TKey2>[] ids)
        {
            var entities = GetEntities(ids);
            set.RemoveRange(entities);
        }

        #endregion
    }

}
