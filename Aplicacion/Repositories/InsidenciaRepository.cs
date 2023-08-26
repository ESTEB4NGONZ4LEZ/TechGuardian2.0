
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class InsidenciaRepository : GenericRepository<Insidencia>, IInsidencia
{
    private readonly MainContext _context;
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
}
