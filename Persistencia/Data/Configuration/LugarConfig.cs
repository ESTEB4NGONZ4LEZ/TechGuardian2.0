
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class LugarConfig : IEntityTypeConfiguration<Lugar>
{
    public void Configure(EntityTypeBuilder<Lugar> builder)
    {
        builder.ToTable("lugar");

        builder.Property(x => x.Nombre)
        .HasMaxLength(50)
        .IsRequired();

        builder.HasOne(a => a.Area)
        .WithMany(e => e.Lugares)
        .HasForeignKey(i => i.Id_area)
        .IsRequired();
    }
}
