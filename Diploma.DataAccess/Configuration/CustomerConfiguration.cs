using Diploma.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configuration
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(b => b.AddressLine1)
                .IsRequired();

            builder.Property(b => b.AddressLine2);
        }
    }
}
