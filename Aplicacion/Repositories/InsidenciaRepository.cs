
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class InsidenciaRepository : GenericRepository<Insidencia>, IInsidencia
{
    public InsidenciaRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Insidencia>> GetAllAsync()
    {
        return await _context.Insidencias.ToListAsync();
    }
    public override async Task<Insidencia> GetByIdAsync(int id)
    {
        return await _context.Insidencias.FindAsync(id);
    }
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Insidencia> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Insidencias as IQueryable<Insidencia>;
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
