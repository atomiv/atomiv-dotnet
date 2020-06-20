using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Configurations
{
    public class OrderItemStatusRecordConfiguration : IEntityTypeConfiguration<OrderItemStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderItemStatusRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Id)
                .HasConversion<byte>();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}