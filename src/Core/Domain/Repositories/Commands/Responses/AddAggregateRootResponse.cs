using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class AddAggregateRootResponse<TAggregateRoot> : IResponse
        where TAggregateRoot : IAggregateRoot
    {
        public AddAggregateRootResponse(TAggregateRoot aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
        }

        public TAggregateRoot AggregateRoot { get; }
    }
}