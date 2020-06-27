using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Atomiv.Infrastructure.MongoDb
{
    public class Record<TId>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public TId Id { get; set; }
    }
}
