using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(z => z.ShopDate);
            builder.Property(z => z.Total).IsRequired();
            
            builder.HasOne(c => c.Client)
            .WithMany(c => c.Sales)
            .HasForeignKey(c => c.ClientId);

            builder.HasOne(x => x.Payment)
            .WithOne(x => x.Sale);
        }
    }
}