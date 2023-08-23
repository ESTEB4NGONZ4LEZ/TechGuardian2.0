
using Dominio.Base;

namespace Dominio.Entities;

public class CompoCompu : BaseEntity
{
    public int Id_computador { get; set; }
    public int Id_tipo_componente { get; set; }
    public Computador Computador { get; set; }
    public Componente Componente { get; set; }
}
