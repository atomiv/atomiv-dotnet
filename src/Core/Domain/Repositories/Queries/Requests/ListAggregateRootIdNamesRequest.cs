namespace Optivem.Framework.Core.Domain
{
    public class ListAggregateRootIdNamesRequest<TResponse, TAggregateRoot, TIdentity, TId>
        : IAggregateRootRequest<ListAggregateRootIdNamesResponse<TId>, TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public ListAggregateRootIdNamesRequest(string nameFilter)
        {
            NameFilter = nameFilter;
        }

        public string NameFilter { get; }
    }
}