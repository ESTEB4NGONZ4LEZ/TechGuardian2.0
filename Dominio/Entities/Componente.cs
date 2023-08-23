
using Dominio.Base;

namespace Dominio.Entities;

public class Componente : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<CompoCompu> CompoCompus { get; set; }
}
