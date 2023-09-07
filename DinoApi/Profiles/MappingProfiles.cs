
using AutoMapper;
using DinoApi.Dtos.Area;
using Dominio.Entities;

namespace DinoApi.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Area, AreaDto>().ReverseMap();
        CreateMap<Area, AreaxLugarDto>().ReverseMap();
        CreateMap<Arl, ArlDto>().ReverseMap();
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
        CreateMap<CompoCompu, CompoCompuDto>().ReverseMap();
        CreateMap<Componente, ComponenteDto>().ReverseMap();
        CreateMap<Computador, ComputadorDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Eps, EpsDto>().ReverseMap();
        CreateMap<Estado, EstadoDto>().ReverseMap();
        CreateMap<Insidencia, InsidenciaDto>().ReverseMap();
        CreateMap<Lugar, LugarDto>().ReverseMap();
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<TipoDocumento, TipoDocumentoDto>().ReverseMap();
        CreateMap<TipoEmail, TipoEmailDto>().ReverseMap();
        CreateMap<TipoInsidencia, TipoInsidenciaDto>().ReverseMap();
        CreateMap<TipoTelefono, TipoTelefonoDto>().ReverseMap();
    }
}
