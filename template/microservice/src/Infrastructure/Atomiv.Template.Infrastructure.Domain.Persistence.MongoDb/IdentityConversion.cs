using Atomiv.Core.Domain;
using MongoDB.Bson;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb
{
    public static class IdentityConversion
    {
        /*
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
        */

        public static Guid ToObjectId(this Guid value)
        {
            return value;
            // return ObjectId.Parse(value);
        }

        public static Guid? TryToObjectId(this Guid value)
        {
            return value;
            /*
            var success = ObjectId.TryParse(value, out ObjectId objectId);
            return success ? objectId : (ObjectId?)null;
            */
        }

        public static Guid ToObjectId(this Identity<Guid> id)
        {
            return ToObjectId(id.Value);
        }

        public static Guid? TryToObjectId(this Identity<Guid> id)
        {
            return TryToObjectId(id.Value);
        }

    }
}
