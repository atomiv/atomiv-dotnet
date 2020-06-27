using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Infrastructure.MongoDb
{
    public class GuidRecord : Record<Guid>
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public new Guid Id { get; set; }
    }
}
