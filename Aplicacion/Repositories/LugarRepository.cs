
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class LugarRepository : GenericRepository<Lugar>, ILugar
{
    private readonly MainContext _context;
    public LugarRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Lugar>> GetAllAsync()
    {
        return await _context.Lugares.ToListAsync();
    }
    public override async Task<Lugar> GetByIdAsync(int id)
    {
        return await _context.Lugares.FindAsync(id);
    }
}
