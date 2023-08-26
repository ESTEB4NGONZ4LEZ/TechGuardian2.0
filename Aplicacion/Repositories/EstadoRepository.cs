
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class EstadoRepository : GenericRepository<Estado>, IEstado
{
    private readonly MainContext _context;
    public EstadoRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Estados.ToListAsync();
    }
    public override async Task<Estado> GetByIdAsync(int id)
    {
        return await _context.Estados.FindAsync(id);
    }
}
