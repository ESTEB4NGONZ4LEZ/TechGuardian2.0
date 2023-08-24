
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CompoCompuConfig : IEntityTypeConfiguration<CompoCompu>
{
    public void Configure(EntityTypeBuilder<CompoCompu> builder)
    {
        builder.ToTable("compo_compu");

        builder.HasOne(a => a.Computador)
        .WithMany(e => e.CompoCompus)
        .HasForeignKey(i => i.Id_computador)
        .IsRequired();

        builder.HasOne(a => a.Componente)
        .WithMany(e => e.CompoCompus)
        .HasForeignKey(i => i.Id_tipo_componente)
        .IsRequired();
    }
}
