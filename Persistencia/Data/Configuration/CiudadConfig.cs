
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CiudadConfig : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(x => x.Nombre)
        .HasMaxLength(30)
        .IsRequired();

        builder.HasOne(a => a.Departamento)
        .WithMany(e => e.Ciudades)
        .HasForeignKey(i => i.Id_departamento)
        .IsRequired();
    }
}
