
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly MainContext _context;
    public DepartamentoRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }
    public override async Task<Departamento> GetByIdAsync(int id)
    {
        return await _context.Departamentos.FindAsync(id);
    }
}
