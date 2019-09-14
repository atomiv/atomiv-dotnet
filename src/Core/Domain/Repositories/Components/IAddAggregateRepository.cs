using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IAddAggregateRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot);
    }
}
