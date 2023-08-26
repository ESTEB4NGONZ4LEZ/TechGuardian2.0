
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class TipoEmailRepository : GenericRepository<TipoEmail>, ITipoEmail
{
    private readonly MainContext _context;
    public TipoEmailRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<TipoEmail>> GetAllAsync()
    {
        return await _context.TipoEmails.ToListAsync();
    }
    public override async Task<TipoEmail> GetByIdAsync(int id)
    {
        return await _context.TipoEmails.FindAsync(id);
    }
}
