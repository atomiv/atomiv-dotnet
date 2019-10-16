namespace Optivem.Framework.Core.Domain
{
    public class UpdateAggregateRootRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<UpdateAggregateRootResponse, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public UpdateAggregateRootRequest(TAggregateRoot aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
        }

        public TAggregateRoot AggregateRoot { get; }
    }
}