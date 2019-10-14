using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRecordConfiguration : IEntityTypeConfiguration<OrderRecord>
    {
        public void Configure(EntityTypeBuilder<OrderRecord> builder)
        {
            builder.ToTable("order");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.CustomerRecordId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.Property(e => e.OrderStatusRecordId)
                .HasColumnName("status_id")
                .IsRequired();

            builder.HasOne(e => e.CustomerRecord)
                .WithMany(e => e.OrderRecords)
                .HasForeignKey(e => e.CustomerRecordId);

            builder.HasOne(e => e.OrderStatusRecord)
                .WithMany(e => e.OrderRecords)
                .HasForeignKey(e => e.OrderStatusRecordId);
        }
    }
}
