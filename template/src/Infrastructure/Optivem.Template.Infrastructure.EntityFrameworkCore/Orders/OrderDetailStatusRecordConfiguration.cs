using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailStatusRecordConfiguration : IEntityTypeConfiguration<OrderDetailStatusRecord>
    {
        public void Configure(EntityTypeBuilder<OrderDetailStatusRecord> builder)
        {
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}