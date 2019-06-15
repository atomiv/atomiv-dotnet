using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public interface IIdentityFactory<TIdentity>
        where TIdentity : IIdentity
    {
        TIdentity Create();
    }

    public interface IIdentityFactory<TIdentity, TId>
        where TIdentity : IIdentity<TId>
    {
        TIdentity Create(TId id);
    }
}
