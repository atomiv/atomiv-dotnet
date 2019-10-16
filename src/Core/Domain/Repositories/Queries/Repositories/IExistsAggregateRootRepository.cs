using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IExistsAggregateRootRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task<bool> ExistsAsync(TIdentity identity);
    }
}