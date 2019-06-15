using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
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
