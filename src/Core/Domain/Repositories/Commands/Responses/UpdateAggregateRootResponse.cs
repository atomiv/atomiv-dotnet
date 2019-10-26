using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class UpdateAggregateRootResponse<TAggregateRoot> : IResponse
        where TAggregateRoot : IAggregateRoot
    {
        public UpdateAggregateRootResponse(TAggregateRoot aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
        }

        public TAggregateRoot AggregateRoot { get; }
    }
}