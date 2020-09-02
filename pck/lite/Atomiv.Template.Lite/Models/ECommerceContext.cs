using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Lite.Models;

// TODO VC TodoApi.Models
namespace Atomiv.Template.Lite.Models
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Atomiv.Template.Lite.Models.Product> Product { get; set; }
    }
}