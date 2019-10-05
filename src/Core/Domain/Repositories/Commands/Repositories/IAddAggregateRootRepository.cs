using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IAddAggregateRootRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot);
    }
}
