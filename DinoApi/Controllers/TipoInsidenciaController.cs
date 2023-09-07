
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class TipoInsidenciaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TipoInsidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TipoInsidenciaDto>> Get()
    {
        var tipoInsidencia = await _unitOfWork.TipoInsidencias.GetAllAsync();
        return _mapper.Map<List<TipoInsidenciaDto>>(tipoInsidencia);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoInsidenciaDto>> Post(TipoInsidenciaDto data)
    {
        var tipoInsidencia = _mapper.Map<TipoInsidencia>(data);
        if(tipoInsidencia == null) return BadRequest();
        _unitOfWork.TipoInsidencias.Add(tipoInsidencia);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Post), new { id = tipoInsidencia.Id }, tipoInsidencia);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoInsidenciaDto>> Put(int id, [FromBody] TipoInsidenciaDto dataUpdate)
    {
        if(dataUpdate == null) return NotFound();
        var tipoInsidencia = _mapper.Map<TipoInsidencia>(dataUpdate);
        tipoInsidencia.Id = id;
        _unitOfWork.TipoInsidencias.Update(tipoInsidencia);
        await _unitOfWork.SaveAsync();
        return dataUpdate;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var tipoInsidencia = await _unitOfWork.TipoInsidencias.GetByIdAsync(id);
        if(tipoInsidencia == null) return NotFound();
        _unitOfWork.TipoInsidencias.Remove(tipoInsidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoInsidenciaDto>> GetByIdAsync(int id)
    {
        var tipoInsidencia = await _unitOfWork.TipoInsidencias.GetByIdAsync(id);
        if(tipoInsidencia == null) return NotFound(); 
        return _mapper.Map<TipoInsidenciaDto>(tipoInsidencia);
    }
}
