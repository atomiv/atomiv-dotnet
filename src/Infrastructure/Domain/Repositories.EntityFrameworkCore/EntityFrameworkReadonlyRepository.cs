using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Ports.Out.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Domain.Repositories.EntityFrameworkCore
{
    public class EntityFrameworkReadonlyRepository<TContext, TEntity, TKey> : IReadonlyRepository<TEntity, TKey>
        where TContext : DbContext
        where TEntity : class, IEntity<TKey>
    {
        protected readonly TContext context;
        protected readonly DbSet<TEntity> set;

        public EntityFrameworkReadonlyRepository(TContext context)
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

        #region Helper - Read

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

        #endregion
    }
}
