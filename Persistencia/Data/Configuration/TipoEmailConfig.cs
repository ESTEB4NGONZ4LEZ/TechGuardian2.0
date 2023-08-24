
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoEmailConfig : IEntityTypeConfiguration<TipoEmail>
{
    public void Configure(EntityTypeBuilder<TipoEmail> builder)
    {
        builder.ToTable("tipo_email");

        builder.Property(x => x.Nombre)
        .HasMaxLength(30)
        .IsRequired();

        builder.Property(x => x.Descripcion)
        .HasMaxLength(255)
        .IsRequired();
    }
}
