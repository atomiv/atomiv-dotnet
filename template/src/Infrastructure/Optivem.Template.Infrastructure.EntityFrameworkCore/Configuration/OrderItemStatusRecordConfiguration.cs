using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Records;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Configuration
{
    public class OrderItemStatusRecordConfiguration : IEntityTypeConfiguration<OrderItemStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderItemStatusRecord> builder)
        {
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}