using Atomiv.Core.Domain;
using SequentialGuid;
using System;

namespace Atomiv.Infrastructure.SequentialGuid
{
    public abstract class IdentityGenerator<TIdentity> : IGenerator<TIdentity>, IIdentityGenerator<TIdentity>
    {
        public TIdentity Next()
        {
            var value = SequentialSqlGuidGenerator.Instance.NewGuid();
            return Create(value);
        }

        protected abstract TIdentity Create(Guid value);
    }
}
