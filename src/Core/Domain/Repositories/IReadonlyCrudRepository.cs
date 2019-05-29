using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface IReadonlyCrudRepository<TAggregateRoot, TIdentity> : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        #region Read

        // TODO: VC: RECHECK

        /*
        IEnumerable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> filter = null,
            Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TAggregateRoot, object>>[] includes);

        Task<IEnumerable<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>> filter = null,
            Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null,
            int? skip = null, int? take = null,
            params Expression<Func<TAggregateRoot, object>>[] includes);


        TAggregateRoot GetSingle(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        Task<TAggregateRoot> GetSingleAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        TAggregateRoot GetSingleOrDefault(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        Task<TAggregateRoot> GetSingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        TAggregateRoot GetFirst(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        Task<TAggregateRoot> GetFirstAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        TAggregateRoot GetFirstOrDefault(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        Task<TAggregateRoot> GetFirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes);

        long GetCount(Expression<Func<TAggregateRoot, bool>> filter = null);

        Task<long> GetCountAsync(Expression<Func<TAggregateRoot, bool>> filter = null);

        bool GetExists(Expression<Func<TAggregateRoot, bool>> filter = null);

        Task<bool> GetExistsAsync(Expression<Func<TAggregateRoot, bool>> filter = null);

        */

        IEnumerable<TAggregateRoot> Get();

        Task<IEnumerable<TAggregateRoot>> GetAsync();

        TAggregateRoot GetSingleOrDefault(TIdentity id);

        Task<TAggregateRoot> GetSingleOrDefaultAsync(TIdentity id);

        bool GetExists(TIdentity id);

        Task<bool> GetExistsAsync(TIdentity id);

        #endregion Read
    }
}