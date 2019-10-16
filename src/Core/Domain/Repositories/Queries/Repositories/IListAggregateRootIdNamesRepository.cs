using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IListAggregateRootIdNamesRepository<TAggregateRoot, TIdentity, TId>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task<ListAggregateRootIdNamesResponse<TId>> ListIdNamesAsync(string nameFilter);
    }
}