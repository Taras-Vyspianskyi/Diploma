using Diploma.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.DataAccess.Configuration
{
    public class TimeToOrderConfiguration : IEntityTypeConfiguration<TimeToOrder>
    {
        public void Configure(EntityTypeBuilder<TimeToOrder> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.OrderId)
                .IsRequired();

            builder.Property(b => b.Minutes)
                .IsRequired();
        }
    }
}
