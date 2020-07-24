using Atomiv.Core.Domain;
using SequentialGuid;
using System;

namespace Atomiv.Infrastructure.SequentialGuid
{
    public abstract class GuidIdentityGenerator<TIdentity> : IGenerator<TIdentity>
    {
        public TIdentity Next()
        {
            var value = SequentialSqlGuidGenerator.Instance.NewGuid();
            return Create(value);
        }

        protected abstract TIdentity Create(Guid value);
    }
}
