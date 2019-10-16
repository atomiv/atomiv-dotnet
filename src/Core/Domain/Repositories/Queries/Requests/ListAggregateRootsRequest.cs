namespace Optivem.Framework.Core.Domain
{
    public class ListAggregateRootsRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<ListAggregateRootsResponse<TAggregateRoot>, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public ListAggregateRootsRequest()
        {
        }
    }
}