﻿using System.Threading.Tasks;

namespace Optivem.Framework.Core.Domain
{
    public interface IFindAggregateRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        Task<TAggregateRoot> GetAsync(TIdentity identity);
    }
}
