using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IAddAggregateRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        TIdentity Add(TAggregateRoot aggregateRoot);

        Task<TIdentity> AddAsync(TAggregateRoot aggregateRoot);
    }
}
