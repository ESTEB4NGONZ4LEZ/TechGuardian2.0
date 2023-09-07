
using Dominio.Entities;

namespace DinoApi.Dtos.Area;

public class AreaxLugarDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<LugarDto> Lugares { get; set; }
}
