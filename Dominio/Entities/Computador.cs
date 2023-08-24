
using Dominio.Base;

namespace Dominio.Entities;

public class Computador : BaseEntity
{
    public string Descripcion { get; set; }
    public int Id_lugar { get; set; }
    public Lugar Lugar { get; set; }
    public ICollection<CompoCompu> CompoCompus { get; set; }
    public ICollection<Insidencia> Insidencias { get; set; }
}
