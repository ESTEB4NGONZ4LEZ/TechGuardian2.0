
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly MainContext _context;
    public PaisRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises.ToListAsync();
    }
    public override async Task<Pais> GetByIdAsync(int id)
    {
        return await _context.Paises.FindAsync(id);
    }
}
