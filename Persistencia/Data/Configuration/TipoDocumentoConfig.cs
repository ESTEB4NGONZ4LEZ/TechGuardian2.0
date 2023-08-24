
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoDocumentoConfig : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("tipo_docuemento");

        builder.Property(x => x.Nombre)
        .HasMaxLength(30)
        .IsRequired();

        builder.Property(x => x.Descripcion)
        .HasMaxLength(255)
        .IsRequired();
    }
}
