
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    public PersonaRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas.ToListAsync();
    }
    public override async Task<Persona> GetByIdAsync(int id)
    {
        return await _context.Personas.FindAsync(id);
    }
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Persona> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Personas as IQueryable<Persona>;
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
