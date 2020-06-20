using Microsoft.EntityFrameworkCore;
using Cli.Infrastructure.EntityFrameworkCore.MyFoos.Configurations;
using Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records;

namespace Cli.Infrastructure.EntityFrameworkCore
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