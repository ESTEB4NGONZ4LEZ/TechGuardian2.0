
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DinoApi.Dtos;
using DinoApi.Dtos.JWT;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DinoApi.Services;

public class UserServices : IUserServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<Usuario> _passwordHasher;
    private readonly JWT _jwt;
    public UserServices(IUnitOfWork unitOfWork, IPasswordHasher<Usuario> passwordHasher, IOptions<JWT> jwt)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwt = jwt.Value;
    }
    public async Task<string> RegisterUserAsync(RegisterUsuarioDto datosUsuario)
    {
        var usuarioExiste = _unitOfWork.Usuarios
                                       .Find(x => x.Username.ToLower() == datosUsuario.Username.ToLower())
                                       .FirstOrDefault();
        if(usuarioExiste == null)
        {
            var usuario = new Usuario
            {
                Username = datosUsuario.Username,
                Email = datosUsuario.Email
            };
            usuario.Password = _passwordHasher.HashPassword(usuario, datosUsuario.Password);
            var rolExist = _unitOfWork.Roles
                                      .Find(x => x.Nombre == datosUsuario.Rol)
                                      .FirstOrDefault();
            if(rolExist == null)
            {
                return $"El rol {datosUsuario.Rol} no existe";
            }
            else
            {
                var rol = _unitOfWork.Roles
                                     .GetRolIdByName(datosUsuario.Rol);
                usuario.IdRol = rol;
            }
            try
            {
                _unitOfWork.Usuarios.Add(usuario);
                await _unitOfWork.SaveAsync();  
                return $"El usuario {datosUsuario.Username} se ha registrado correctamente";
                
            } 
            catch (Exception error)
            {
                return $"Error {error.Message}";
            }
        }
        else 
        {
            return $"El usuario {datosUsuario.Username} ya esta registrado.";
        }
    }
    public async Task<DatosUsuarioDto> LoginAsync(LoginDto datosUsuario)
    {
        var usuario = await _unitOfWork.Usuarios
                                       .GetUserByUsernameAsync(datosUsuario.Username);
        DatosUsuarioDto modelDatosUsuario = new();
        if(usuario == null)
        {
            modelDatosUsuario.EstaAutenticado = false;
            modelDatosUsuario.Mensaje = $"El usuario {datosUsuario.Username} no esta registrado";
            return modelDatosUsuario;
        }
        var passwordVerify = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, datosUsuario.Password);
        if(passwordVerify == PasswordVerificationResult.Success)
        {
            modelDatosUsuario.Mensaje = "Ok";
            modelDatosUsuario.EstaAutenticado = true;
            modelDatosUsuario.UserName = datosUsuario.Username;
            modelDatosUsuario.Email = usuario.Email;
            modelDatosUsuario.Token = CrearToken(usuario);
            return modelDatosUsuario;
        }
        else
        {
            modelDatosUsuario.EstaAutenticado = true;
            modelDatosUsuario.Mensaje = $"Credenciales incorrectas para el usuario {datosUsuario.Username}";
            return modelDatosUsuario;
        }
    }
    public string CrearToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var byteKey = Encoding.UTF8.GetBytes(_jwt.Key);
        var userRol = _unitOfWork.Roles
                                 .GetRolNameById(usuario);
        var tokenDes = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, usuario.Username),
                new("roles", userRol)
            }),
            Issuer = _jwt.Issuer,
            Audience = _jwt.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                                                            SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDes);
        return tokenHandler.WriteToken(token);
    }
}
