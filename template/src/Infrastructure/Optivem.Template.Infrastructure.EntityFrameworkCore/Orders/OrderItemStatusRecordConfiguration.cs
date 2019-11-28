using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderItemStatusRecordConfiguration : IEntityTypeConfiguration<OrderItemStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderItemStatusRecord> builder)
        {
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}