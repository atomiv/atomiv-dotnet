using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailRecordConfiguration : IEntityTypeConfiguration<OrderDetailRecord>
    {
        public void Configure(EntityTypeBuilder<OrderDetailRecord> builder)
        {
            builder.Property(e => e.Quantity)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.OrderDetailStatus)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderDetailStatusId);
        }
    }
}