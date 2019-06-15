using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public interface IRemoveAggregateRepository<TAggregateRoot, TIdentity> 
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        void Delete(TIdentity identity);
    }
}
