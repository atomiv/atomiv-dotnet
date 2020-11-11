using Atomiv.Core.Domain;

namespace Atomiv.Infrastructure.MongoDB
{
    public class Repository<TDbContext> : IRepository
    {
        public Repository(TDbContext context)
        {
            Context = context;
        }

        protected TDbContext Context { get; }
    }
}
