
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class AreaRepository : GenericRepository<Area>, IArea
{
    private readonly MainContext _context;
    public AreaRepository(MainContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _context.Areas.ToListAsync();
    }
    public override async Task<Area> GetByIdAsync(int id)
    {
        return await _context.Areas.FindAsync(id);    
    }
}
