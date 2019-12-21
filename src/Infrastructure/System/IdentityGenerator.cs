using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.System
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
