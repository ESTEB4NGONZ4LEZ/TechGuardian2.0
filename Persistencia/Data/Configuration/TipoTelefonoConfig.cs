
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoTelefonoConfig : IEntityTypeConfiguration<TipoTelefono>
{
    public void Configure(EntityTypeBuilder<TipoTelefono> builder)
    {
        builder.ToTable("tipo_telefono");

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();
    }
}
