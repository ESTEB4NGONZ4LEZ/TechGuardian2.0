
using Dominio.Base;

namespace Dominio.Entities;

public class Categoria : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Insidencia> Insicencias { get; set; }
}
