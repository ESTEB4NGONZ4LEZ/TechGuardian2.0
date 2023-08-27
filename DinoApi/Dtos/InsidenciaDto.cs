
namespace Dominio.Entities;

public class InsidenciaDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public DateOnly Fecha { get; set; }
    public int Id_estado { get; set; }
    public int Id_persona { get; set; }
    public int Id_computador { get; set; }
    public int Id_categoria { get; set; }
    public int Id_tipo_insidencia { get; set; }
    public int Id_lugar { get; set; }
}
