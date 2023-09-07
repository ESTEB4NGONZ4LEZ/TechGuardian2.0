
using System.ComponentModel.DataAnnotations;

namespace DinoApi.Dtos;

public class RegisterUsuarioDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Rol { get; set; }
}
