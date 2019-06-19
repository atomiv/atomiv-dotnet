using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface IFindAggregateRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {

        TAggregateRoot GetSingleOrDefault(TIdentity id);

        Task<TAggregateRoot> GetSingleOrDefaultAsync(TIdentity id);


    }
}
