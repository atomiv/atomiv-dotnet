using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface IRepository<TEntity, TId> : IReadonlyRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>
    {
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

        void DeleteRange(IEnumerable<TId> ids);

        void DeleteRange(params TId[] ids);

        #endregion
    }
}
