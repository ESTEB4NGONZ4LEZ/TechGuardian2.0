
namespace Dominio.Entities;

public class DepartamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Id_pais { get; set; }
    public Pais Pais { get; set; }
}
