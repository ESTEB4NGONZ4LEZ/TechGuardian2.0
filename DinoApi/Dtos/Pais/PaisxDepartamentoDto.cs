
namespace Dominio.Entities;

public class PaisxDepartamentoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<DepartamentoDto> Departamentos { get; set; }
}
