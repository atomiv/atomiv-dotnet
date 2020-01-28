using Optivem.Atomiv.Core.Domain;
using System;

namespace Optivem.Atomiv.Infrastructure.System
{
    public abstract class IdentityGenerator<TIdentity> : IIdentityGenerator<TIdentity>
    {
        public TIdentity Next()
        {
            var guid = Guid.NewGuid();
            return Create(guid);
        }

        protected abstract TIdentity Create(Guid guid);
    }
}
