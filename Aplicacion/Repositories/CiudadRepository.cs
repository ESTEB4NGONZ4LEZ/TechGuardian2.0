
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    public CiudadRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades.ToListAsync();    
    }
    public override async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.Ciudades.FindAsync(id);
    }
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Ciudad> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Ciudades as IQueryable<Ciudad>;
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
