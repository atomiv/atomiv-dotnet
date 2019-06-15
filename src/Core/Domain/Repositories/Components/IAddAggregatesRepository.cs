using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface IAddAggregatesRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        void AddRange(IEnumerable<TAggregateRoot> aggregateRoots);

        Task AddRangeAsync(IEnumerable<TAggregateRoot> aggregateRoots);

        void AddRange(params TAggregateRoot[] aggregateRoots);

        Task AddRangeAsync(params TAggregateRoot[] aggregateRoots);
    }
}
