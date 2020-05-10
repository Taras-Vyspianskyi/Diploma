using Diploma.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diploma.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Surname)
                .IsRequired();
        }
    }
}
