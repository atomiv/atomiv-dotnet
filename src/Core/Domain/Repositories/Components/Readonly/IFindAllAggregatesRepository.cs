using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface IFindAllAggregatesRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        IEnumerable<TAggregateRoot> Get();

        Task<IEnumerable<TAggregateRoot>> GetAsync();
    }
}
