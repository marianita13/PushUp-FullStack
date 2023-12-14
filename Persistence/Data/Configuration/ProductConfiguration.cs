
using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.HasIndex(r => r.ClotheId).IsUnique();
            builder.Property(x => x.ClotheId).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.StockMinimo).IsRequired();
            builder.Property(x => x.StockMaximo).IsRequired();
            builder.Property(x => x.Image);

            builder.HasOne(d => d.Category)
            .WithMany(d => d.Products)
            .HasForeignKey(d => d.CategoryId);
        }
    }
}