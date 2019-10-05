using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IFilterAggregateRootsRepository<TAggregateRoot, TIdentity, TFilter, TSort>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task FilterAsync(TFilter filter, TSort sort, int page, int size);
    }
}
