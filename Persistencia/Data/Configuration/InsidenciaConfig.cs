
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class InsidenciaConfig : IEntityTypeConfiguration<Insidencia>
{
    public void Configure(EntityTypeBuilder<Insidencia> builder)
    {
        builder.ToTable("insidencia");

        builder.Property(x => x.Descripcion)
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(x => x.Fecha)
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(a => a.Estado)
        .WithMany(e => e.Insidencias)
        .HasForeignKey(i => i.Id_estado)
        .IsRequired();

        builder.HasOne(a => a.Persona)
        .WithMany(e => e.Insidencias)
        .HasForeignKey(i => i.Id_persona)
        .IsRequired();

        builder.HasOne(a => a.Computador)
        .WithMany(e => e.Insidencias)
        .HasForeignKey(i => i.Id_computador)
        .IsRequired();

        builder.HasOne(a => a.Categoria)
        .WithMany(e => e.Insicencias)
        .HasForeignKey(i => i.Id_categoria)
        .IsRequired();

        builder.HasOne(a => a.TipoInsidencia)
        .WithMany(e => e.Insidencias)
        .HasForeignKey(i => i.Id_tipo_insidencia)
        .IsRequired();

        builder.HasOne(a => a.Area)
        .WithMany(e => e.Insidencias)
        .HasForeignKey(i => i.Id_area)
        .IsRequired();
    }
}
