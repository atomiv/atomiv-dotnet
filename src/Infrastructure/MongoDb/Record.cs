using MongoDB.Bson.Serialization.Attributes;

namespace Atomiv.Infrastructure.MongoDb
{
    public class Record<TId>
    {
        [BsonId]
        public TId Id { get; set; }
    }
}
