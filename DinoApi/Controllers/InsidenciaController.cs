
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class InsidenciaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public InsidenciaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<InsidenciaDto>> GetInsidencia()
    {
        var insidencias = await _unitOfWork.Insidencias.GetAllAsync();
        return _mapper.Map<List<InsidenciaDto>>(insidencias);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InsidenciaDto>> PostInsidencia(InsidenciaDto dataInsidencia)
    {
        var insidencia = _mapper.Map<Insidencia>(dataInsidencia);
        if(insidencia == null) return BadRequest();
        _unitOfWork.Insidencias.Add(insidencia);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostInsidencia), new { id = insidencia.Id }, insidencia);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InsidenciaDto>> PutInsidencia(int id, [FromBody] InsidenciaDto dataUpdateInsidencia)
    {
        if(dataUpdateInsidencia == null) return NotFound();
        var insidencia = _mapper.Map<Insidencia>(dataUpdateInsidencia);
        insidencia.Id = id;
        _unitOfWork.Insidencias.Update(insidencia);
        await _unitOfWork.SaveAsync();
        return dataUpdateInsidencia;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteInsidencia(int id)
    {
        var insidencia = await _unitOfWork.Insidencias.GetByIdAsync(id);
        if(insidencia == null) return NotFound();
        _unitOfWork.Insidencias.Remove(insidencia);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InsidenciaDto>> GetByIdAsyncInsidencia(int id)
    {
        var insidencia = await _unitOfWork.Insidencias.GetByIdAsync(id);
        if(insidencia == null) return NotFound(); 
        return _mapper.Map<InsidenciaDto>(insidencia);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<InsidenciaDto>>> GetInsidenciaWhithPage([FromQuery] Params insidenciaParams)
    {
        var insidencia = await _unitOfWork.Insidencias.GetAllAsync
        (
            insidenciaParams.PageIndex,
            insidenciaParams.PageSize,
            insidenciaParams.Search
        );
        var lstInsidencias = _mapper.Map<List<InsidenciaDto>>(insidencia.registros);
        return new Pager<InsidenciaDto>
        (
            lstInsidencias,
            insidencia.totalRegistros,
            insidenciaParams.PageIndex,
            insidenciaParams.PageSize,
            insidenciaParams.Search
        );
    }
}
