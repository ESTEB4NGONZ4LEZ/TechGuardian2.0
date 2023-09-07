
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class LugarRepository : GenericRepository<Lugar>, ILugar
{
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
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Lugar> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Lugares as IQueryable<Lugar>;
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
