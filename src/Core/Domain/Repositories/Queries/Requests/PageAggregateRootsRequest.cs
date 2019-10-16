namespace Optivem.Framework.Core.Domain
{
    public class PageAggregateRootsRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<PageAggregateRootsResponse<TAggregateRoot>, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public PageAggregateRootsRequest(int page, int size)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; }

        public int Size { get; }
    }
}