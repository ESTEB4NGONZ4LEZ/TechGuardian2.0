
using Dominio.Base;

namespace Dominio.Entities;

public class Estado : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Insidencia> Insidencias { get; set; }    
}
