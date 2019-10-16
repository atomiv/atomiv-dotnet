using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class ListAggregateRootsResponse<TAggregateRoot> : IResponse
        where TAggregateRoot : IAggregateRoot
    {
        public ListAggregateRootsResponse(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            AggregateRoots = aggregateRoots;
        }

        public IEnumerable<TAggregateRoot> AggregateRoots { get; }
    }
}