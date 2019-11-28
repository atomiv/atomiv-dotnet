using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Records;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Configuration
{
    public class OrderStatusRecordConfiguration : IEntityTypeConfiguration<OrderStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderStatusRecord> builder)
        {
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}