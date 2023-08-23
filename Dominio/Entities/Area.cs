
using Dominio.Base;

namespace Dominio.Entities;

public class Area : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<Insidencia> Insidencias { get; set; }
    public ICollection<Lugar> Lugares { get; set; }
}
