using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Commons.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Read

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TEntity, object>>[] includes);

        TEntity GetSingle(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        
        long GetCount(Expression<Func<TEntity, bool>> filter = null);

        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        bool GetExists(Expression<Func<TEntity, bool>> filter = null);

        Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null);
        
        #endregion

        #region Create

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void AddRange(params TEntity[] entities);

        Task AddRangeAsync(params TEntity[] entities);

        #endregion

        #region Update

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void UpdateRange(params TEntity[] entities);

        #endregion

        #region Delete

        void Delete(TEntity entity);
        
        void DeleteRange(IEnumerable<TEntity> entities);
        
        void DeleteRange(params TEntity[] entities);

        #endregion
    }
    
    public interface IRepository<TEntity, TKey> : IRepository<TEntity>
        where TEntity : class
    {
        #region Read

        TEntity GetSingleOrDefault(TKey id);

        Task<TEntity> GetSingleOrDefaultAsync(TKey id);

        bool GetExists(TKey id);

        Task<bool> GetExistsAsync(TKey id);

        #endregion

        #region Delete

        void DeleteRange(IEnumerable<TKey> ids);

        void DeleteRange(params TKey[] ids);

        #endregion
    }

    public interface IRepository<TEntity, TKey1, TKey2> : IRepository<TEntity>
        where TEntity : class
    {
        #region Read

        TEntity GetSingleOrDefault(TKey1 id1, TKey2 id2);

        TEntity GetSingleOrDefault(Tuple<TKey1, TKey2> id);

        Task<TEntity> GetSingleOrDefaultAsync(TKey1 id1, TKey2 id2);

        Task<TEntity> GetSingleOrDefaultAsync(Tuple<TKey1, TKey2> id);

        bool GetExists(TKey1 id1, TKey2 id2);

        bool GetExists(Tuple<TKey1, TKey2> id);

        Task<bool> GetExistsAsync(TKey1 id1, TKey2 id2);

        Task<bool> GetExistsAsync(Tuple<TKey1, TKey2> id);

        #endregion

        #region Delete

        void DeleteRange(IEnumerable<Tuple<TKey1, TKey2>> ids);

        void DeleteRange(params Tuple<TKey1, TKey2>[] ids);

        #endregion
    }
}
