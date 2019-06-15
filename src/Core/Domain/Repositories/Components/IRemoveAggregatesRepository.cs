using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public interface IRemoveAggregatesRepository<TAggregateRoot, TIdentity>
        : IRepository<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        void DeleteRange(IEnumerable<TIdentity> identities);

        void DeleteRange(params TIdentity[] identities);
    }
}
