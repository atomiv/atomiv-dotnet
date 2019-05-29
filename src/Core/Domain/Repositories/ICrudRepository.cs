using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface ICrudRepository<TAggregateRoot, TIdentity> : IReadonlyCrudRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        #region Create

        TIdentity Add(TAggregateRoot aggregateRoot);

        Task<TIdentity> AddAsync(TAggregateRoot aggregateRoot);

        void AddRange(IEnumerable<TAggregateRoot> aggregateRoots);

        Task AddRangeAsync(IEnumerable<TAggregateRoot> aggregateRoots);

        void AddRange(params TAggregateRoot[] aggregateRoots);

        Task AddRangeAsync(params TAggregateRoot[] aggregateRoots);

        #endregion Create

        #region Update

        void Update(TAggregateRoot aggregateRoot);

        void UpdateRange(IEnumerable<TAggregateRoot> aggregateRoots);

        void UpdateRange(params TAggregateRoot[] aggregateRoots);

        #endregion Update

        #region Delete

        // TODO: VC: DELETE

        /*
        void Delete(TAggregateRoot aggregateRoot);

        void DeleteRange(IEnumerable<TAggregateRoot> aggregateRoots);

        void DeleteRange(params TAggregateRoot[] aggregateRoots);

        */

        void Delete(TIdentity identity);

        void DeleteRange(IEnumerable<TIdentity> identities);

        void DeleteRange(params TIdentity[] identities);

        #endregion Delete
    }
}