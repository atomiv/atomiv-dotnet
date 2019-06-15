using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
{
    public interface ICrudRepository<TAggregateRoot, TIdentity> 
        : IReadonlyRepository<TAggregateRoot, TIdentity>,
            IAddAggregateRepository<TAggregateRoot, TIdentity>,
            IAddAggregatesRepository<TAggregateRoot, TIdentity>,
            IRemoveAggregateRepository<TAggregateRoot, TIdentity>,
            IRemoveAggregatesRepository<TAggregateRoot, TIdentity>,
            IUpdateAggregateRepository<TAggregateRoot, TIdentity>,
            IUpdateAggregatesRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {

    }
}