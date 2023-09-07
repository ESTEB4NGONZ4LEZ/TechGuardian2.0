
using AutoMapper;
using DinoApi.Dtos.Area;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<DepartamentoDto>> GetDepartamento()
    {
        var departamentos = await _unitOfWork.Departamentos.GetAllAsync();
        return _mapper.Map<List<DepartamentoDto>>(departamentos);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> PostDepartamento(DepartamentoDto dataDepartamento)
    {
        var departamento = _mapper.Map<Departamento>(dataDepartamento);
        if(departamento == null) return BadRequest();
        _unitOfWork.Departamentos.Add(departamento);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostDepartamento), new { id = departamento.Id }, departamento);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> PutDepartamento(int id, [FromBody] DepartamentoDto dataUpdateDepartamento)
    {
        if(dataUpdateDepartamento == null) return NotFound();
        var departamento = _mapper.Map<Departamento>(dataUpdateDepartamento);
        departamento.Id = id;
        _unitOfWork.Departamentos.Update(departamento);
        await _unitOfWork.SaveAsync();
        return dataUpdateDepartamento;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteDepartamento(int id)
    {
        var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if(departamento == null) return NotFound();
        _unitOfWork.Departamentos.Remove(departamento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartamentoDto>> GetByIdAsyncDepartamento(int id)
    {
        var departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
        if(departamento == null) return NotFound(); 
        return _mapper.Map<DepartamentoDto>(departamento);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DepartamentoDto>>> GetADepartamentoWhithPage([FromQuery] Params departamentoParams)
    {
        var departamento = await _unitOfWork.Departamentos.GetAllAsync
        (
            departamentoParams.PageIndex,
            departamentoParams.PageSize,
            departamentoParams.Search
        );
        var lstDepartamentos = _mapper.Map<List<DepartamentoDto>>(departamento.registros);
        return new Pager<DepartamentoDto>
        (
            lstDepartamentos,
            departamento.totalRegistros,
            departamentoParams.PageIndex,
            departamentoParams.PageSize,
            departamentoParams.Search
        );
    }
}
