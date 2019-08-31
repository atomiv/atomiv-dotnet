using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optivem.Generator.Infrastructure.EntityFrameworkCore.Customers.Records;

namespace Optivem.Generator.Infrastructure.EntityFrameworkCore.Customers.Configurations
{
    public class CustomerRecordConfiguration : IEntityTypeConfiguration<CustomerRecord>
    {
        public void Configure(EntityTypeBuilder<CustomerRecord> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}