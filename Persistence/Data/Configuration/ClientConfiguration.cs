using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Phone).HasMaxLength(10);
        }
    }
}