
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class RolRepository : GenericRepository<Rol>, IRol
{
    public RolRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Rol>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }
    public override async Task<Rol> GetByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public int GetRolIdByName(string rol)
    {
        return _context.Roles
                       .Where(x => x.Nombre == rol)
                       .Select(x => x.Id)
                       .FirstOrDefault();
    }

    public string GetRolNameById(Usuario usuario)
    {
        return _context.Roles
                       .Where(x => x.Id == usuario.IdRol)
                       .Select(x => x.Nombre)
                       .FirstOrDefault();
    }
}
