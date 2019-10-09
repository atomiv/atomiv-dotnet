using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailRecordConfiguration : IEntityTypeConfiguration<OrderDetailRecord>
    {
        public void Configure(EntityTypeBuilder<OrderDetailRecord> builder)
        {
            builder.ToTable("order_detail");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.OrderRecordId)
                .HasColumnName("order_id")
                .IsRequired();

            builder.Property(e => e.ProductRecordId)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(e => e.StatusRecordId)
                .HasColumnName("status_id")
                .IsRequired();

            builder.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
