
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumento
{
    private readonly MainContext _context;
    public TipoDocumentoRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<TipoDocumento>> GetAllAsync()
    {
        return await _context.TipoDocumentos.ToListAsync();
    }
    public override async Task<TipoDocumento> GetByIdAsync(int id)
    {
        return await _context.TipoDocumentos.FindAsync(id);
    }
}
