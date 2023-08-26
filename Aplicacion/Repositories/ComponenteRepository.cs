
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class ComponenteRepository : GenericRepository<Componente>, IComponente
{
    private readonly MainContext _context;
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

}
