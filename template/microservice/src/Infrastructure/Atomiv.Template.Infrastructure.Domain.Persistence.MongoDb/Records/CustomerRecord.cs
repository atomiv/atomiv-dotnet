using Atomiv.Infrastructure.MongoDb;
using MongoDB.Bson;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records
{
    public class CustomerRecord : Record<ObjectId>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
