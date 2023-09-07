
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    public CategoriaRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _context.Categorias.ToListAsync();
    }
    public override async Task<Categoria> GetByIdAsync(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }
}
