
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class EpsRepository : GenericRepository<Eps>, IEps
{
    private readonly MainContext _context;
    public EpsRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Eps>> GetAllAsync()
    {
        return await _context.Eps.ToListAsync();
    }  
    public override async Task<Eps> GetByIdAsync(int id)
    {
        return await _context.Eps.FindAsync(id);
    }
}
