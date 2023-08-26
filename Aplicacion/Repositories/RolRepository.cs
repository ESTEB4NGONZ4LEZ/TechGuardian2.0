
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly MainContext _context;
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
}
