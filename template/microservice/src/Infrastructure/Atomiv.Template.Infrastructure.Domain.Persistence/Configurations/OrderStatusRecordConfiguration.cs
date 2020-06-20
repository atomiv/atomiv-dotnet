using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Configurations
{
    public class OrderStatusRecordConfiguration : IEntityTypeConfiguration<OrderStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderStatusRecord> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}