
using Dominio.Entities;

namespace Dominio.Interface;

public interface IRol : IGeneric<Rol>
{
    string GetRolNameById(Usuario usuario);
    int GetRolIdByName(string rol);
}