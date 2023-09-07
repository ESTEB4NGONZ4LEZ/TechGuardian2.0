
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repositories;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    public UsuarioRepository(MainContext context) : base(context)
    {
    }
    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }
    public override async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }   
    public async Task<Usuario> GetUserByUsernameAsync(string username)
    {
        return _context.Usuarios
                       .Include(x => x.Roles)
                       .FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
    }
    public override async Task
    <(
        int totalRegistros,
        IEnumerable<Usuario> registros
    )> GetAllAsync
    (
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Usuarios as IQueryable<Usuario>;
        if(!string.IsNullOrEmpty(search)) 
        {
            query = query.Where(x => x.Username.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
