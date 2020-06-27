using Atomiv.Infrastructure.MongoDb;
using MongoDB.Bson;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records
{
    public class ProductRecord : Record<ObjectId>
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal ListPrice { get; set; }

        public bool IsListed { get; set; }
    }
}
