using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDB
{
    public class Repository : Repository<MongoDBContext>
    {
        public Repository(MongoDBContext context) : base(context)
        {
        }
    }
}
