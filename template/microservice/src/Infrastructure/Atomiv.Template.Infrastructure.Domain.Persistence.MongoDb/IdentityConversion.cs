using Atomiv.Core.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb
{
    public static class IdentityConversion
    {
        public static ObjectId ToObjectId(this string value)
        {
            return ObjectId.Parse(value);
        }

        public static ObjectId? TryToObjectId(this string value)
        {
            var success = ObjectId.TryParse(value, out ObjectId objectId);
            return success ? objectId : (ObjectId?)null;
        }

        public static ObjectId ToObjectId(this Identity<string> id)
        {
            return ToObjectId(id.Value);
        }

        public static ObjectId? TryToObjectId(this Identity<string> id)
        {
            return TryToObjectId(id.Value);
        }
    }
}
