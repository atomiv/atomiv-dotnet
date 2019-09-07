using Microsoft.EntityFrameworkCore;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Configurations;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers.Records;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products.Records;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerRecord> Customer { get; set; }

        public virtual DbSet<ProductRecord> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerRecordConfiguration());
        }
    }
}