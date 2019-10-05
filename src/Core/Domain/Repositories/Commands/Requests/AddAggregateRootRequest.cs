using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class AddAggregateRootRequest<TAggregateRoot, TIdentity> 
        : IAggregateRootRequest<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public AddAggregateRootRequest(TAggregateRoot aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
        }

        public TAggregateRoot AggregateRoot { get; }
    }
}
