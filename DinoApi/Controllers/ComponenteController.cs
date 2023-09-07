
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ComponenteController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ComponenteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ComponenteDto>> GetComponente()
    {
        var componentes = await _unitOfWork.Componentes.GetAllAsync();
        return _mapper.Map<List<ComponenteDto>>(componentes);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ComponenteDto>> PostComponente(ComponenteDto dataComponente)
    {
        var componente = _mapper.Map<Componente>(dataComponente);
        if(componente == null) return BadRequest();
        _unitOfWork.Componentes.Add(componente);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostComponente), new { id = componente.Id }, componente);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ComponenteDto>> PutComponente(int id, [FromBody] ComponenteDto dataUpdateComponente)
    {
        if(dataUpdateComponente == null) return NotFound();
        var componente = _mapper.Map<Componente>(dataUpdateComponente);
        componente.Id = id;
        _unitOfWork.Componentes.Update(componente);
        await _unitOfWork.SaveAsync();
        return dataUpdateComponente;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteComponente(int id)
    {
        var componente = await _unitOfWork.Componentes.GetByIdAsync(id);
        if(componente == null) return NotFound();
        _unitOfWork.Componentes.Remove(componente);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ComponenteDto>> GetByIdAsyncComponente(int id)
    {
        var componente = await _unitOfWork.Componentes.GetByIdAsync(id);
        if(componente == null) return NotFound(); 
        return _mapper.Map<ComponenteDto>(componente);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ComponenteDto>>> GetComponenteWhithPage([FromQuery] Params componenteParams)
    {
        var componente = await _unitOfWork.Componentes.GetAllAsync
        (
            componenteParams.PageIndex,
            componenteParams.PageSize,
            componenteParams.Search
        );
        var lstComponentes = _mapper.Map<List<ComponenteDto>>(componente.registros);
        return new Pager<ComponenteDto>
        (
            lstComponentes,
            componente.totalRegistros,
            componenteParams.PageIndex,
            componenteParams.PageSize,
            componenteParams.Search
        );
    }
}
