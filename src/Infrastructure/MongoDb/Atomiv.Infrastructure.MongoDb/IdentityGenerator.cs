using Atomiv.Core.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Infrastructure.MongoDb
{
    public abstract class IdentityGenerator<TIdentity> : IIdentityGenerator<TIdentity>
    {
        public TIdentity Next()
        {
            var value = ObjectId.GenerateNewId();
            return Create(value);
        }

        protected abstract TIdentity Create(ObjectId value);
    }
}
