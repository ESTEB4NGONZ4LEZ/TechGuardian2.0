
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class ComputadorRepository : GenericRepository<Computador>, IComputador
{
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
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Computador> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Computadores as IQueryable<Computador>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
