using Optivem.Framework.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Domain
{
    public class AddAggregateRootsResponse<TAggregateRoot> : IResponse
        where TAggregateRoot : IAggregateRoot
    {
        public AddAggregateRootsResponse(IEnumerable<TAggregateRoot> aggregateRoots)
        {
            AggregateRoots = aggregateRoots;
        }

        public IEnumerable<TAggregateRoot> AggregateRoots { get; }
    }
}
