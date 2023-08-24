
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CateforiaConfig : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("categoria");

        builder.Property(x => x.Nombre)
        .HasMaxLength(30)
        .IsRequired();

        builder.Property(x => x.Descripcion)
        .HasMaxLength(255)
        .IsRequired();
    }
}
