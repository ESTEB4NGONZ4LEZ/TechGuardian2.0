
using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Arl> Arl { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<CompoCompu> CompoCompus { get; set; }
    public DbSet<Componente> Componentes { get; set; }
    public DbSet<Computador> Computadores { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Eps> Eps { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Insidencia> Insidencias { get; set; }
    public DbSet<Lugar> Lugares { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<TipoDocumento> TipoDocumentos { get; set; }
    public DbSet<TipoEmail> TipoEmails { get; set; }
    public DbSet<TipoInsidencia> TipoInsidencias { get; set; }
    public DbSet<TipoTelefono> TipoTelefonos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompoCompu>().HasKey(x => new { x.Id_computador, x.Id_tipo_componente});
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
