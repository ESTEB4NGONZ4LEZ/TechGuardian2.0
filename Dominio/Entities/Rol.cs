
using Dominio.Base;

namespace Dominio.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Persona> Personas { get; set; }
}
