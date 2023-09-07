
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class CompoCompuRepository : GenericRepository<CompoCompu>, ICompoCompu
{
    public CompoCompuRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<CompoCompu>> GetAllAsync()
    {
        return await _context.CompoCompus.ToListAsync();    
    }
    public override async Task<CompoCompu> GetByIdAsync(int id)
    {
        return await _context.CompoCompus.FindAsync(id);
    }
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<CompoCompu> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.CompoCompus as IQueryable<CompoCompu>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
