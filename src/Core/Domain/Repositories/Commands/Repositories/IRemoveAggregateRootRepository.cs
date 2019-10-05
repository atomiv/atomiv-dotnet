using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IRemoveAggregateRootRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task RemoveAsync(TIdentity identity);
    }
}
