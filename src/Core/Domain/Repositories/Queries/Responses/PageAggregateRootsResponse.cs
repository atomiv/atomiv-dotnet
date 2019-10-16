using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class PageAggregateRootsResponse<TAggregateRoot> : IResponse
        where TAggregateRoot : IAggregateRoot
    {
        public PageAggregateRootsResponse(IEnumerable<TAggregateRoot> aggregateRoots, int totalPages, int totalRecords)
        {
            AggregateRoots = aggregateRoots;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        public IEnumerable<TAggregateRoot> AggregateRoots { get; }

        public int TotalPages { get; }

        public int TotalRecords { get; }
    }
}