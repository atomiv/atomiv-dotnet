using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Records;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Configuration
{
    public class OrderRecordConfiguration : IEntityTypeConfiguration<OrderRecord>
    {
        public void Configure(EntityTypeBuilder<OrderRecord> builder)
        {
            builder.HasOne(e => e.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerId);

            builder.HasOne(e => e.OrderStatus)
                .WithMany(e => e.OrderRecords)
                .HasForeignKey(e => e.OrderStatusId);
        }
    }
}