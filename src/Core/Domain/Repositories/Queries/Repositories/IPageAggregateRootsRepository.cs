using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IPageAggregateRootsRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task<PageAggregateRootsResponse<TAggregateRoot>> PageAsync(int page, int size);
    }
}