using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            
        }
    }
}