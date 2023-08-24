
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class PersonaConfig : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Apellido)
        .HasMaxLength(50)
        .IsRequired();

        builder.Property(x => x.Telefono)
        .HasMaxLength(20)
        .IsRequired();

        builder.Property(x => x.Email)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasOne(a => a.Ciudad)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_ciudad)
        .IsRequired();

        builder.HasOne(a => a.Eps)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_eps)
        .IsRequired();

        builder.HasOne(a => a.Arl)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_arl)
        .IsRequired();

        builder.HasOne(a => a.TipoTelefono)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_tipo_telefono)
        .IsRequired();

        builder.HasOne(a => a.TipoEmail)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_tipo_email)
        .IsRequired();

        builder.HasOne(a => a.Lugar)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_lugar)
        .IsRequired();

        builder.HasOne(a => a.TipoDocumento)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_tipo_documento)
        .IsRequired();

        builder.HasOne(a => a.Rol)
        .WithMany(e => e.Personas)
        .HasForeignKey(i => i.Id_rol)
        .IsRequired();
    }
}
