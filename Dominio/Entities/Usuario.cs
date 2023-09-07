
using Dominio.Base;

namespace Dominio.Entities;

public class Usuario : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int IdRol { get; set; }
    public Rol Roles { get; set; }
}
