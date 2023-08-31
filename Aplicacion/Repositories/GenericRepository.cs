
using System.Linq.Expressions;
using Dominio.Base;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class GenericRepository<T> : IGeneric<T> where T : BaseEntity
{
    protected readonly MainContext _context;
    public GenericRepository(MainContext context)
    {
        _context = context;
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    public virtual async Task
        <(
            int totalRegistros, 
            IEnumerable<T> registros
        )> GetAllAsync
        (
            int pageIndex, 
            int pageSize, 
            string search
        )
    {
        var totalRegistros = await _context.Set<T>().CountAsync();
        var registros = await _context.Set<T>()
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

}
