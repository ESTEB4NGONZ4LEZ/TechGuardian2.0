
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class EstadoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<EstadoDto>> GetEstado()
    {
        var estado = await _unitOfWork.Estados.GetAllAsync();
        return _mapper.Map<List<EstadoDto>>(estado);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoDto>> PostEstado(EstadoDto dataEstado)
    {
        var estado = _mapper.Map<Estado>(dataEstado);
        if(estado == null) return BadRequest();
        _unitOfWork.Estados.Add(estado);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostEstado), new { id = estado.Id }, estado);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EstadoDto>> PutEstado(int id, [FromBody] EstadoDto dataUpdateEstado)
    {
        if(dataUpdateEstado == null) return NotFound();
        var estado = _mapper.Map<Estado>(dataUpdateEstado);
        estado.Id = id;
        _unitOfWork.Estados.Update(estado);
        await _unitOfWork.SaveAsync();
        return dataUpdateEstado;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteEstado(int id)
    {
        var estado = await _unitOfWork.Estados.GetByIdAsync(id);
        if(estado == null) return NotFound();
        _unitOfWork.Estados.Remove(estado);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoDto>> GetByIdAsyncEstado(int id)
    {
        var estado = await _unitOfWork.Estados.GetByIdAsync(id);
        if(estado == null) return NotFound(); 
        return _mapper.Map<EstadoDto>(estado);
    }
}
