using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderStatusRecordConfiguration : IEntityTypeConfiguration<OrderStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderStatusRecord> builder)
        {
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}