
using System.ComponentModel.DataAnnotations;

namespace DinoApi.Dtos.JWT;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
