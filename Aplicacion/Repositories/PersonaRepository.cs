
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly MainContext _context;
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
}
