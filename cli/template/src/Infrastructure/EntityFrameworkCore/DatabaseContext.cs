using Microsoft.EntityFrameworkCore;
using Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Configurations;
using Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records;

namespace Optivem.Cli.Infrastructure.EntityFrameworkCore
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyFooRecord> MyFoos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MyFooRecordConfiguration());
        }
    }
}