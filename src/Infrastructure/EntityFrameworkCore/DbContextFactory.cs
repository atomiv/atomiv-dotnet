using Microsoft.EntityFrameworkCore;
using System;

namespace Atomiv.Infrastructure.EntityFrameworkCore
{
    public class DbContextFactory<TDbContext> : BaseDbContextFactory<TDbContext>
        where TDbContext : DbContext

    {
        private readonly Func<DbContextOptions<TDbContext>, TDbContext> _createDbContext;

        public DbContextFactory(DbContextOptions<TDbContext> contextOptions, Func<DbContextOptions<TDbContext>, TDbContext> createDbContext)
            : base(contextOptions)
        {
            _createDbContext = createDbContext;
        }

        protected override TDbContext Create(DbContextOptions<TDbContext> options)
        {
            return _createDbContext(options);
        }
    }
}