
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EstadoConfig : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estado");

        builder.Property(x => x.Nombre)
        .HasMaxLength(30)
        .IsRequired();

        builder.Property(x => x.Descripcion)
        .HasMaxLength(255)
        .IsRequired();
    }
}
