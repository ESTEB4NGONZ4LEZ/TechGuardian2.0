
namespace Dominio.Entities;

public class PersonaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public int Id_ciudad { get; set; }
    public int Id_eps { get; set; }
    public int Id_arl { get; set; }
    public int Id_tipo_telefono { get; set; }
    public int Id_tipo_email { get; set; }
    public int Id_lugar { get; set; }
    public int Id_tipo_documento { get; set; }
    public int Id_rol { get; set; }
}
