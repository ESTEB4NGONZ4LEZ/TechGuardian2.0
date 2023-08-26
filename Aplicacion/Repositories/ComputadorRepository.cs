
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class ComputadorRepository : GenericRepository<Computador>, IComputador
{
    private readonly MainContext _context;
    public ComputadorRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Computador>> GetAllAsync()
    {
        return await _context.Computadores.ToListAsync();
    }
    public override async Task<Computador> GetByIdAsync(int id)
    {
        return await _context.Computadores.FindAsync(id);
    }
}
