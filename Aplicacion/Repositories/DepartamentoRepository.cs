
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    public DepartamentoRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }
    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos.FindAsync(id);
    }
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Departamento> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Departamentos as IQueryable<Departamento>;
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
