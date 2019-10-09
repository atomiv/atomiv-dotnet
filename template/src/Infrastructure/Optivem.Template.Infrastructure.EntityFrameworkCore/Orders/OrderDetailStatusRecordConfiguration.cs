using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailStatusRecordConfiguration : IEntityTypeConfiguration<OrderDetailStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderDetailStatusRecord> builder)
        {
            builder.ToTable("order_detail_status");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
