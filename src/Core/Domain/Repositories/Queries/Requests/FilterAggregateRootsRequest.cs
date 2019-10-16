using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class FilterAggregateRootsRequest<TAggregateRoot, TIdentity, TFilter, TSort>
        : IAggregateRootRequest<FilterAggregateRootsResponse<TAggregateRoot>, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public FilterAggregateRootsRequest(TFilter filter, TSort sort, int page, int size)
        {
            Filter = filter;
            Sort = sort;
            Page = page;
            Size = size;
        }

        public TFilter Filter { get; }

        public TSort Sort { get; }

        public int Page { get; }

        public int Size { get; }
    }
}
