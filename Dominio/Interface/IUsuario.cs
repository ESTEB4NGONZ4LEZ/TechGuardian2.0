
using Dominio.Entities;

namespace Dominio.Interface;

public interface IUsuario : IGeneric<Usuario>
{
    Task<Usuario> GetUserByUsernameAsync(string username);
}
