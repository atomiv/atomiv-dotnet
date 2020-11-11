using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(IOptions<MongoDBOptions> options)
            : base(options)
        {
            Customers = Database.GetCollection<CustomerRecord>(CollectionNames.Customers);
            Products = Database.GetCollection<ProductRecord>(CollectionNames.Products);
            Orders = Database.GetCollection<OrderRecord>(CollectionNames.Orders);
        }

        public IMongoCollection<CustomerRecord> Customers { get; }

        public IMongoCollection<ProductRecord> Products { get; }

        public IMongoCollection<OrderRecord> Orders { get; }
    }
}
