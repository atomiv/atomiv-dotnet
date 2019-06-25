using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public interface IUpdateAggregatesRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        void UpdateRange(IEnumerable<TAggregateRoot> aggregateRoots);

        void UpdateRange(params TAggregateRoot[] aggregateRoots);
    }
}
