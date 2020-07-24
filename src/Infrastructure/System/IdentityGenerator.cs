using Atomiv.Core.Domain;
using System;

namespace Atomiv.Infrastructure.System
{
    public abstract class IdentityGenerator<TIdentity> : IGenerator<TIdentity>
    {
        public TIdentity Next()
        {
            var guid = Guid.NewGuid();
            return Create(guid);
        }

        protected abstract TIdentity Create(Guid guid);
    }
}
