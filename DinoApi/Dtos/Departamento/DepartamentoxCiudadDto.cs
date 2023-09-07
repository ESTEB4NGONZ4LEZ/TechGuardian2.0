
namespace Dominio.Entities;

public class DepartamentoxCiudadDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<CiudadDto> Ciudades { get; set; }
}
