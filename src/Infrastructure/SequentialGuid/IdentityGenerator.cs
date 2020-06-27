using Atomiv.Core.Domain;
using SequentialGuid;
using System;

namespace Atomiv.Infrastructure.SequentialGuid
{
    public abstract class IdentityGenerator<TIdentity> : IIdentityGenerator<TIdentity>
    {
        public TIdentity Next()
        {
            var guid = SequentialSqlGuidGenerator.Instance.NewGuid();
            var value = guid.ToString();
            return Create(value);
        }

        protected abstract TIdentity Create(string value);
    }
}
