using MongoDB.Bson.Serialization.Attributes;

namespace Atomiv.Infrastructure.MongoDB
{
    public class Record<TId>
    {
        [BsonId]
        public TId Id { get; set; }
    }
}
