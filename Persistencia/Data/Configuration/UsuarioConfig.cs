
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.Property(x => x.Username)
        .HasMaxLength(50)
        .IsUnicode()
        .IsRequired();

        builder.Property(x => x.Email)
        .HasMaxLength(100)
        .IsUnicode()
        .IsRequired();

        builder.Property(x => x.Password)
        .IsRequired();

        builder.HasOne(a => a.Roles)
        .WithMany(e => e.Usuarios)
        .HasForeignKey(i => i.IdRol)
        .IsRequired();
    }
}
