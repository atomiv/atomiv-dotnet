using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace Atomiv.Infrastructure.MongoDB
{
    public class GuidRecord : Record<Guid>
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public new Guid Id { get; set; }
    }
}
