
using Dominio.Base;

namespace Dominio.Entities;

public class TipoInsidencia : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Insidencia> Insidencias { get; set; }
}
