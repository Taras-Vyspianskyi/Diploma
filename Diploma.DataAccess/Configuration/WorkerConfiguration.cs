using Diploma.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configuration
{
    class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.TransportType)
                .IsRequired();

            builder.Property(b => b.Category)
                .IsRequired();

            builder.Property(b => b.CrewId)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
