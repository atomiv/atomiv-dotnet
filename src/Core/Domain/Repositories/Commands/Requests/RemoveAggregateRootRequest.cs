using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class RemoveAggregateRootRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public RemoveAggregateRootRequest(TIdentity identity)
        {
            Identity = identity;
        }

        public TIdentity Identity { get; }
    }
}
