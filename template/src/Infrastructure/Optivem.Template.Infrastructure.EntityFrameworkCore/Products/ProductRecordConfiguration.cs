using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductRecordConfiguration : IEntityTypeConfiguration<ProductRecord>
    {
        public void Configure(EntityTypeBuilder<ProductRecord> builder)
        {
            builder.ToTable("product");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.ProductCode)
                .HasColumnName("code")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.ProductName)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ListPrice)
                .HasColumnName("list_price")
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.IsActive)
                .HasColumnName("active")
                .IsRequired();
        }
    }
}
