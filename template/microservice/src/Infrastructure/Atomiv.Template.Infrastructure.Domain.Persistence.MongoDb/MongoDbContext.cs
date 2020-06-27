using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb
{
    public class MongoDbContext
    {
        public MongoDbContext(IDbSettings settings)
        {
            // TODO: VC: Remove this when reading config works
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "WebShopDb";

            Client = new MongoClient(settings.ConnectionString);
            Database = Client.GetDatabase(settings.DatabaseName);

            Products = Database.GetCollection<ProductRecord>(CollectionNames.Products);
        }

        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public IMongoCollection<ProductRecord> Products { get; }
    }
}
