
using Dominio.Base;

namespace Dominio.Entities;

public class Insidencia : BaseEntity
{
    public string Descripcion { get; set; }
    public DateOnly Fecha { get; set; }
    public int Id_estado { get; set; }
    public int Id_persona { get; set; }
    public int Id_computador { get; set; }
    public int Id_categoria { get; set; }
    public int Id_tipo_insidencia { get; set; }
    public int Id_area { get; set; }
    public Estado Estado { get; set; }
    public Persona Persona { get; set; }
    public Computador Computador { get; set; }
    public Categoria Categoria { get; set; }
    public TipoInsidencia TipoInsidencia { get; set; }
    public Area Area { get; set; }
}
