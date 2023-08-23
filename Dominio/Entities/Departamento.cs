
using Dominio.Base;

namespace Dominio.Entities;

public class Departamento : BaseEntity
{
    public string Nombre { get; set; }
    public int Id_pais { get; set; }
    public Pais Pais { get; set; }
    public ICollection<Ciudad> Ciudades { get; set; }
}
