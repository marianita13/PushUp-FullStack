using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class MethodPaymentConfiguration : IEntityTypeConfiguration<MethodPayment>
    {
        public void Configure(EntityTypeBuilder<MethodPayment> builder)
        {
            builder.ToTable("MethodPayment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(100);
        }
    }
}