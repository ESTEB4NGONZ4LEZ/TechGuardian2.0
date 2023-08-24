
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ComputadorConfig : IEntityTypeConfiguration<Computador>
{
    public void Configure(EntityTypeBuilder<Computador> builder)
    {
        builder.ToTable("computador");

        builder.Property(x => x.Descripcion)
        .HasMaxLength(255)
        .IsRequired();

        builder.HasOne(a => a.Lugar)
        .WithMany(e => e.Computadores)
        .HasForeignKey(i => i.Id_lugar)
        .IsRequired();
    }
}
