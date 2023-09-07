
using Dominio.Base;

namespace Dominio.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Usuario> Usuarios { get; set; }
}
