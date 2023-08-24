
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoInsidenciaConfig : IEntityTypeConfiguration<TipoInsidencia>
{
    public void Configure(EntityTypeBuilder<TipoInsidencia> builder)
    {
        builder.ToTable("tipo_insidencia");

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Descripcion)
        .HasMaxLength(255)
        .IsRequired();
    }
}
