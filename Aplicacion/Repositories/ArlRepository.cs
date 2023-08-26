
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class ArlRepository : GenericRepository<Arl>, IArl
{
    private readonly MainContext _context;
    public ArlRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Arl>> GetAllAsync()
    {
        return await _context.Arl.ToListAsync();
    }
    public override async Task<Arl> GetByIdAsync(int id)
    {
        return await _context.Arl.FindAsync(id);
    }
}
