
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class AreaRepository : GenericRepository<Area>, IArea
{
    public AreaRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _context.Areas.ToListAsync();
    }
    public override async Task<Area> GetByIdAsync(int id)
    {
        return await _context.Areas.FindAsync(id);    
    }
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Area> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Areas as IQueryable<Area>;
        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(x => x.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
