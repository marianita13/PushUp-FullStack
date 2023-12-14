using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.NumCard).HasMaxLength(20);
            
            builder.HasOne(e => e.MethodPayment)
            .WithMany(e => e.Payments)
            .HasForeignKey(e => e.MethodPaymentId);

            builder.HasOne(x => x.Sale)
            .WithOne(x => x.Payment)
            .HasForeignKey<Payment>(x => x.Id);
        }
    }
}