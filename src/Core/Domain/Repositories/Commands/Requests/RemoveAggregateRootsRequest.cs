using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class RemoveAggregateRootsRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<RemoveAggregateRootsResponse, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public RemoveAggregateRootsRequest(IEnumerable<TIdentity> identities)
        {
            Identities = identities;
        }

        public IEnumerable<TIdentity> Identities { get; }
    }
}
