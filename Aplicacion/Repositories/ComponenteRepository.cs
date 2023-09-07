
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class ComponenteRepository : GenericRepository<Componente>, IComponente
{
    public ComponenteRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Componente>> GetAllAsync()
    {
        return await _context.Componentes.ToListAsync();
    }
    public override async Task<Componente> GetByIdAsync(int id)
    {
        return await _context.Componentes.FindAsync(id);
    }

    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Componente> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Componentes as IQueryable<Componente>;
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
