
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly MainContext _context;
    public CiudadRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades.ToListAsync();    
    }
    public override async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.Ciudades.FindAsync(id);
    }
}
