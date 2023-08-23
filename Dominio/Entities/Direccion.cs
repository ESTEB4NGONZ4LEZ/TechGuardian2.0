
using Dominio.Base;

namespace Dominio.Entities;

public class Direccion : BaseEntity
{ 
    public int Id_persona { get; set; }
    public string Calle { get; set; }
    public string Carrera { get; set; }
    public string Numero { get; set; }
    public string Diagonal { get; set; }
    public string Barrio { get; set; }
    public string Detalle { get; set; }
    public Persona Persona { get; set; }
}
