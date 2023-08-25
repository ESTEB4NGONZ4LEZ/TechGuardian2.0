
using Dominio.Base;

namespace Dominio.Entities;

public class Lugar : BaseEntity
{
    public string Nombre { get; set; }
    public int Id_area { get; set; }
    public Area Area { get; set; }
    public ICollection<Computador> Computadores { get; set; }
    public ICollection<Persona> Personas { get; set; }
    public ICollection<Insidencia> Insidencias { get; set; }
}
