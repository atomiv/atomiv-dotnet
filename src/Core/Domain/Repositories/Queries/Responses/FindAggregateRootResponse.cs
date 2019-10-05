using Optivem.Framework.Core.Common;
using System.Collections.Generic;

namespace Optivem.Framework.Core.Domain
{
    public class FindAggregateRootResponse<TAggregateRoot> : IResponse
        where TAggregateRoot : IAggregateRoot
    {
        public FindAggregateRootResponse(TAggregateRoot aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
        }

        public TAggregateRoot AggregateRoot { get; }
    }
}
