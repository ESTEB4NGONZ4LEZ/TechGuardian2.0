
using Dominio.Base;

namespace Dominio.Entities;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public int Id_ciudad { get; set; }
    public int Id_eps { get; set; }
    public int Id_arl { get; set; }
    public int Id_tipo_telefono { get; set; }
    public int Id_tipo_email { get; set; }
    public int Id_lugar { get; set; }
    public int Id_tipo_documento { get; set; }
    public Ciudad Ciudad { get; set; }
    public Eps Eps { get; set; }
    public Arl Arl { get; set; }
    public TipoTelefono TipoTelefono { get; set; }
    public TipoEmail TipoEmail { get; set; }
    public Lugar Lugar { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public ICollection<Insidencia> Insidencias { get; set; }
}
