
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class DireccionConfig : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("direccion");

        builder.HasOne(a => a.Persona)
        .WithMany(e => e.Direcciones)
        .HasForeignKey(i => i.Id_persona)
        .IsRequired();

        builder.Property(x => x.Calle)
        .HasMaxLength(10);

        builder.Property(x => x.Carrera)
        .HasMaxLength(10);

        builder.Property(x => x.Numero)
        .HasMaxLength(10);

        builder.Property(x => x.Diagonal)
        .HasMaxLength(10);

        builder.Property(x => x.Barrio)
        .HasMaxLength(50);

        builder.Property(x => x.Detalle)
        .HasMaxLength(255);
    }
}
