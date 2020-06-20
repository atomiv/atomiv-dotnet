using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Domain;

namespace Atomiv.Infrastructure.EntityFrameworkCore
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