
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class TipoTelefonoRepository : GenericRepository<TipoTelefono>, ITipoTelefono
{
    public TipoTelefonoRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<TipoTelefono>> GetAllAsync()
    {
        return await _context.TipoTelefonos.ToListAsync();
    }
    public override async Task<TipoTelefono> GetByIdAsync(int id)
    {
        return await _context.TipoTelefonos.FindAsync(id);
    }
}
