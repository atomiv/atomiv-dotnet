using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Configurations
{
    public class OrderItemRecordConfiguration : IEntityTypeConfiguration<OrderItemRecord>
    {
        public void Configure(EntityTypeBuilder<OrderItemRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Quantity)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.OrderId);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Status)
                .WithMany(e => e.OrderItems)
                .HasForeignKey(e => e.StatusId);
        }
    }
}