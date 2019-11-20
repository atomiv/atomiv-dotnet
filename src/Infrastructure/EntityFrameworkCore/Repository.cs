using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
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