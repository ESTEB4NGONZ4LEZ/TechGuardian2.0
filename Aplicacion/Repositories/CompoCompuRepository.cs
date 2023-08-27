
using System.Linq.Expressions;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class CompoCompuRepository : ICompoCompu
{
    private readonly MainContext _context;
    public CompoCompuRepository(MainContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<CompoCompu>> GetAllAsync()
    {
        return await _context.Set<CompoCompu>().ToListAsync();
    }
    public async Task<CompoCompu> GetByIdAsync(int id_compu, int id_tip_compo)
    {
        return await _context.Set<CompoCompu>().FindAsync(id_compu, id_tip_compo);
    }
    public void Add(CompoCompu entity)
    {
        _context.Set<CompoCompu>().Add(entity); 
    }
    public void AddRange(CompoCompu entities)
    {
        _context.Set<CompoCompu>().AddRange();
    }
    public void Update(CompoCompu entity)
    {
        _context.Set<CompoCompu>().Update(entity);
    }
    public void Remove(CompoCompu entity)
    {
        _context.Set<CompoCompu>().Remove(entity);
    }

    public void RemoveRange(CompoCompu entities)
    {
        _context.Set<CompoCompu>().RemoveRange(entities);
    }
    public IEnumerable<CompoCompu> Find(Expression<Func<CompoCompu, bool>> expression)
    {
        return _context.Set<CompoCompu>().Where(expression); 
    }
}
