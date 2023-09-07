
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PaisController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<PaisDto>> GetPais()
    {
        var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(paises);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> PostPais(PaisDto dataPais)
    {
        var pais = _mapper.Map<Pais>(dataPais);
        if(pais == null) return BadRequest();
        _unitOfWork.Paises.Add(pais);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostPais), new { id = pais.Id }, pais);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> PutPais(int id, [FromBody] PaisDto dataUpdatePais)
    {
        if(dataUpdatePais == null) return NotFound();
        var pais = _mapper.Map<Pais>(dataUpdatePais);
        pais.Id = id;
        _unitOfWork.Paises.Update(pais);
        await _unitOfWork.SaveAsync();
        return dataUpdatePais;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeletePais(int id)
    {
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null) return NotFound();
        _unitOfWork.Paises.Remove(pais);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> GetByIdAsyncPais(int id)
    {
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null) return NotFound(); 
        return _mapper.Map<PaisDto>(pais);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PaisDto>>> GetPaisWhithPage([FromQuery] Params paisParams)
    {
        var pais = await _unitOfWork.Paises.GetAllAsync
        (
            paisParams.PageIndex,
            paisParams.PageSize,
            paisParams.Search
        );
        var lstPaises = _mapper.Map<List<PaisDto>>(pais.registros);
        return new Pager<PaisDto>
        (
            lstPaises,
            pais.totalRegistros,
            paisParams.PageIndex,
            paisParams.PageSize,
            paisParams.Search
        );
    }
}
