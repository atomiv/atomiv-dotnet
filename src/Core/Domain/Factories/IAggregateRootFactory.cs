using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public interface IAggregateRootFactory<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
        TAggregateRoot Create();
    }

    public interface IAggregateRootFactory<TAggregateRoot, TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        TAggregateRoot Create(TIdentity identity);
    }
}
