using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Rol
            // utilizando el objeto 'builder'.
            builder.ToTable("rol");
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("rolName")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}