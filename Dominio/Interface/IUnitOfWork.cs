
namespace Dominio.Interface;

public interface IUnitOfWork
{
    IArea Areas { get; }
    IArl Arl { get; }
    ICategoria Categorias { get; }
    ICiudad Ciudades { get; }
    ICompoCompu CompoCompus { get; }
    IComponente Componentes { get; }
    IComputador Computadores { get; }
    IDepartamento Departamentos { get; }
    IEps Eps { get; }
    IEstado Estados { get; }
    IInsidencia Insidencias { get; }
    ILugar Lugares { get; }
    IPais Paises { get; }
    IPersona Personas { get; }
    IRol Roles { get; }
    ITipoDocumento TipoDocumentos { get; }
    ITipoEmail TipoEmails { get; }
    ITipoInsidencia TipoInsidencias { get; }
    ITipoTelefono TipoTelefonos { get; }
    IUsuario Usuarios { get; }
    Task<int> SaveAsync();
}

