
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ComputadorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ComputadorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ComputadorDto>> GetComputador()
    {
        var computador = await _unitOfWork.Computadores.GetAllAsync();
        return _mapper.Map<List<ComputadorDto>>(computador);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ComputadorDto>> PostComputador(ComputadorDto dataComputador)
    {
        var computador = _mapper.Map<Computador>(dataComputador);
        if(computador == null) return BadRequest();
        _unitOfWork.Computadores.Add(computador);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostComputador), new { id = computador.Id }, computador);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ComputadorDto>> PutComputador(int id, [FromBody] ComputadorDto dataUpdateComputador)
    {
        if(dataUpdateComputador == null) return NotFound();
        var computador = _mapper.Map<Computador>(dataUpdateComputador);
        computador.Id = id;
        _unitOfWork.Computadores.Update(computador);
        await _unitOfWork.SaveAsync();
        return dataUpdateComputador;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteComputador(int id)
    {
        var computador = await _unitOfWork.Computadores.GetByIdAsync(id);
        if(computador == null) return NotFound();
        _unitOfWork.Computadores.Remove(computador);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ComputadorDto>> GetByIdAsyncComputador(int id)
    {
        var computador = await _unitOfWork.Computadores.GetByIdAsync(id);
        if(computador == null) return NotFound(); 
        return _mapper.Map<ComputadorDto>(computador);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<ComputadorDto>>> GetComputadorWhithPage([FromQuery] Params computadorParams)
    {
        var computador = await _unitOfWork.Computadores.GetAllAsync
        (
            computadorParams.PageIndex,
            computadorParams.PageSize,
            computadorParams.Search
        );
        var lstComputadores = _mapper.Map<List<ComputadorDto>>(computador.registros);
        return new Pager<ComputadorDto>
        (
            lstComputadores,
            computador.totalRegistros,
            computadorParams.PageIndex,
            computadorParams.PageSize,
            computadorParams.Search
        );
    }
}
