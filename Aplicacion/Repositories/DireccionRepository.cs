
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    private readonly MainContext _context;
    public DireccionRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Direccion>> GetAllAsync()
    {
        return await _context.Direcciones.ToListAsync();
    }
}
