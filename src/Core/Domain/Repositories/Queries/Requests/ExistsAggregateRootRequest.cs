namespace Optivem.Framework.Core.Domain
{
    public class ExistsAggregateRootRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<ExistsAggregateRootResponse, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public ExistsAggregateRootRequest(TIdentity identity)
        {
            Identity = identity;
        }

        public TIdentity Identity { get; }
    }
}