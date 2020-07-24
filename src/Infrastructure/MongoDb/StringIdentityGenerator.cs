using Atomiv.Core.Domain;
using MongoDB.Bson;

namespace Atomiv.Infrastructure.MongoDb
{
    public abstract class StringIdentityGenerator<TIdentity> : IGenerator<TIdentity>
    {
        public TIdentity Next()
        {
            var value = ObjectId.GenerateNewId();
            var valueStr = value.ToString();
            return Create(valueStr);
        }

        protected abstract TIdentity Create(string value);
    }
}
