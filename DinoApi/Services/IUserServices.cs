
using DinoApi.Dtos;
using DinoApi.Dtos.JWT;

namespace DinoApi.Services;

public interface IUserServices 
{
    Task<string> RegisterUserAsync(RegisterUsuarioDto datosUsuario);
    Task<DatosUsuarioDto> LoginAsync(LoginDto datosUsuario);
}
