
namespace Dominio.Entities;

public class ComputadorDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public int Id_lugar { get; set; }
    public Lugar Lugar { get; set; }
}
