namespace Optivem.Framework.Core.Domain
{
    public class FindAggregateRootRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<FindAggregateRootResponse<TAggregateRoot>, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public FindAggregateRootRequest(TIdentity identity)
        {
            Identity = identity;
        }

        public TIdentity Identity { get; }
    }
}