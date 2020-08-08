using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb
{
    public class Repository : Repository<MongoDbContext>
    {
        public Repository(MongoDbContext context) : base(context)
        {
        }
    }
}
