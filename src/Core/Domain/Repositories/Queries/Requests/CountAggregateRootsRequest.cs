using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class CountAggregateRootsRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
    }
}
