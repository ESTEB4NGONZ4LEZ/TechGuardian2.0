
using System.Linq.Expressions;
using Dominio.Base;

namespace Dominio.Interface;

public interface IGeneric<T> where T : BaseEntity
{ 
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id); 
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);

}
