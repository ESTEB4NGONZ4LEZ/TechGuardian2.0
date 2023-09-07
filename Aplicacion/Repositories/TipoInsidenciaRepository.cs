
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class TipoInsidenciaRepository : GenericRepository<TipoInsidencia>, ITipoInsidencia
{
    public TipoInsidenciaRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<TipoInsidencia>> GetAllAsync()
    {
        return await _context.TipoInsidencias.ToListAsync();
    }
    public override async Task<TipoInsidencia> GetByIdAsync(int id)
    {
        return await _context.TipoInsidencias.FindAsync(id);
    }
}
