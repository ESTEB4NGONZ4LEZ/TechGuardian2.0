
using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interface;

public interface ICompoCompu
{
    Task<IEnumerable<CompoCompu>> GetAllAsync();
    Task<CompoCompu> GetByIdAsync(int id_compu, int id_tip_compo);
    void Add(CompoCompu entity);
    void AddRange(CompoCompu entities);
    void Update(CompoCompu entity);
    void Remove(CompoCompu entity);
    void RemoveRange(CompoCompu entities);
    IEnumerable<CompoCompu> Find(Expression<Func<CompoCompu, bool>> expression);
}
