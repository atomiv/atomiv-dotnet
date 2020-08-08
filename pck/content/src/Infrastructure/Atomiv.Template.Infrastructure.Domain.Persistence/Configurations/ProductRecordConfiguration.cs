using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Configurations
{
    public class ProductRecordConfiguration : IEntityTypeConfiguration<ProductRecord>
    {
        public void Configure(EntityTypeBuilder<ProductRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.ProductCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ListPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.IsListed)
                .IsRequired();
        }
    }
}