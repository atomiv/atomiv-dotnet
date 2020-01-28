using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Core.Domain;

namespace Optivem.Atomiv.Infrastructure.EntityFrameworkCore
{
    public class Repository<TDbContext> : IRepository
        where TDbContext : DbContext
    {
        public Repository(TDbContext context)
        {
            Context = context;
        }

        protected TDbContext Context { get; }
    }
}