using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.MongoDb
{
    public static class IMongoCollectionExtensions
    {
        public static Task<long> CountDocumentsAsync<TDocument>(this IMongoCollection<TDocument> collection, CountOptions options = null, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TDocument>.Filter
                .Empty;

            return collection.CountDocumentsAsync(filter, options, cancellationToken);
        }
    }
}
