using Diploma.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.CrewId)
                .IsRequired();

            builder.Property(b => b.CustomerId)
                .IsRequired();

            builder.Property(b => b.OperatorId)
                .IsRequired();

            builder.Property(b => b.Category)
                .IsRequired();

            builder.Property(b => b.Time)
                .IsRequired();

            builder.Property(b => b.Status)
                .IsRequired();

            builder.Property(b => b.Coordinates)
                .IsRequired();
        }
    }
}
