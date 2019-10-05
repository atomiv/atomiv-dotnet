using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class ListAggregateRootIdNamesRequest<TAggregateRoot, TIdentity>
        : IAggregateRootRequest<TAggregateRoot, TIdentity>
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
