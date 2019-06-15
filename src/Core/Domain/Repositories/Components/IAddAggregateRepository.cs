using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Core.Domain
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
