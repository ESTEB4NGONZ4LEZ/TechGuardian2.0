
using Aplicacion.Repositories;
using Dominio.Interface;
using Persistencia;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MainContext _context;
    public UnitOfWork(MainContext context)
    {
        _context = context;
    }
    private AreaRepository _areas;
    private ArlRepository _arl;
    private CategoriaRepository _categorias;
    private CiudadRepository _ciudades;
    private CompoCompuRepository _compo_compu;
    private ComponenteRepository _componentes;
    private ComputadorRepository _computadores;
    private DepartamentoRepository _departamentos;
    private EpsRepository _eps;
    private EstadoRepository _estados;
    private InsidenciaRepository _insidencias;
    private LugarRepository _lugares;
    private PaisRepository _paises;
    private PersonaRepository _personas;
    private RolRepository _roles;
    private TipoDocumentoRepository _tipoDocumentos;
    private TipoEmailRepository _tipoEmail;
    private TipoInsidenciaRepository _tipoInsidencia;
    private TipoTelefonoRepository _tipoTelefono;
    private UsuarioRepository _usuario;
    public IArea Areas
    {
        get
        {
            _areas ??= new AreaRepository(_context);
            return _areas;
        }
        set
        {
            _areas ??= new AreaRepository(_context);
        }
    }
    public IArl Arl
    {
        get
        {
            _arl ??= new ArlRepository(_context);
            return _arl;
        }
        set
        {
            _arl ??= new ArlRepository(_context);
        }
    }
    public ICategoria Categorias
    {
        get
        {
            _categorias ??= new CategoriaRepository(_context);
            return _categorias;
        }
        set
        {
            _categorias ??= new CategoriaRepository(_context);
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            _ciudades ??= new CiudadRepository(_context);
            return _ciudades;
        }
        set
        {
            _ciudades ??= new CiudadRepository(_context);
        }
    }

    public ICompoCompu CompoCompus
    {
        get
        {
            _compo_compu ??= new CompoCompuRepository(_context);
            return _compo_compu;
        }
        set
        {
            _compo_compu ??= new CompoCompuRepository(_context);
        }
    }

    public IComponente Componentes
    {
        get
        {
            _componentes ??= new ComponenteRepository(_context);
            return _componentes;
        }
        set
        {
            _componentes ??= new ComponenteRepository(_context);
        }
    }

    public IComputador Computadores
    {
        get
        {
            _computadores ??= new ComputadorRepository(_context);
            return _computadores;
        }
        set
        {
            _computadores ??= new ComputadorRepository(_context);
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            _departamentos ??= new DepartamentoRepository(_context);
            return _departamentos;
        }
        set
        {
            _departamentos ??= new DepartamentoRepository(_context);
        }
    }

    public IEps Eps
    {
        get
        {
            _eps ??= new EpsRepository(_context);
            return _eps;
        }
        set
        {
            _eps ??= new EpsRepository(_context);
        }
    }

    public IEstado Estados
    {
        get
        {
            _estados ??= new EstadoRepository(_context);
            return _estados;
        }
        set
        {
            _estados ??= new EstadoRepository(_context);
        }
    }

    public IInsidencia Insidencias
    {
        get
        {
            _insidencias ??= new InsidenciaRepository(_context);
            return _insidencias;
        }
        set
        {
            _insidencias ??= new InsidenciaRepository(_context);
        }
    }

    public ILugar Lugares
    {
        get
        {
            _lugares ??= new LugarRepository(_context);
            return _lugares;
        }
        set
        {
            _lugares ??= new LugarRepository(_context);
        }
    }

    public IPais Paises
    {
        get
        {
            _paises ??= new PaisRepository(_context);
            return _paises;
        }
        set
        {
            _paises ??= new PaisRepository(_context);
        }
    }

    public IPersona Personas
    {
        get
        {
            _personas ??= new PersonaRepository(_context);
            return _personas;
        }
        set 
        {
            _personas ??= new PersonaRepository(_context);
        }
    }

    public IRol Roles
    {
        get
        {
            _roles ??= new RolRepository(_context);
            return _roles;
        }
        set
        {
            _roles ??= new RolRepository(_context);
        }
    }

    public ITipoDocumento TipoDocumentos
    {
        get
        {
            _tipoDocumentos ??= new TipoDocumentoRepository(_context);
            return _tipoDocumentos;
        }
        set
        {
            _tipoDocumentos ??= new TipoDocumentoRepository(_context);
        }
    }

    public ITipoEmail TipoEmails
    {
        get
        {
            _tipoEmail ??= new TipoEmailRepository(_context);
            return _tipoEmail;
        }
        set
        {
            _tipoEmail ??= new TipoEmailRepository(_context);
        }
    }

    public ITipoInsidencia TipoInsidencias
    {
        get
        {
            _tipoInsidencia ??= new TipoInsidenciaRepository(_context);
            return _tipoInsidencia;
        }
        set
        {
            _tipoInsidencia ??= new TipoInsidenciaRepository(_context);
        }
    }

    public ITipoTelefono TipoTelefonos
    {
        get
        {
            _tipoTelefono ??= new TipoTelefonoRepository(_context);
            return _tipoTelefono;
        }
        set
        {
            _tipoTelefono ??= new TipoTelefonoRepository(_context);
        }
    }

    public IUsuario Usuarios 
    {
        get
        {
            _usuario ??= new UsuarioRepository(_context);
            return _usuario;
        }
        set
        {
            _usuario ??= new UsuarioRepository(_context);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
