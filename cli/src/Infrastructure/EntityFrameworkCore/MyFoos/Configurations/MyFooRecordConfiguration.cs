using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records;

namespace Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Configurations
{
    public class MyFooRecordConfiguration : IEntityTypeConfiguration<MyFooRecord>
    {
        public void Configure(EntityTypeBuilder<MyFooRecord> builder)
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