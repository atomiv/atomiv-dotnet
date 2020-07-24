using Atomiv.Core.Domain;
using SequentialGuid;

namespace Atomiv.Infrastructure.SequentialGuid
{
    public abstract class StringIdentityGenerator<TIdentity> : IGenerator<TIdentity>
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
