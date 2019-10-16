using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class AddAggregateRootsRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<AddAggregateRootsResponse<TAggregateRoot>, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public AddAggregateRootsRequest(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            AggregateRoots = aggregateRoots;
        }

        public IEnumerable<TAggregateRoot> AggregateRoots { get; }
    }
}
