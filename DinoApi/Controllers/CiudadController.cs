
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class CiudadController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<CiudadDto>> GetCiudad()
    {
        var ciudades = await _unitOfWork.Ciudades.GetAllAsync();
        return _mapper.Map<List<CiudadDto>>(ciudades);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadDto>> PostCiudad(CiudadDto dataCiudad)
    {
        var ciudad = _mapper.Map<Ciudad>(dataCiudad);
        if(ciudad == null) return BadRequest();
        _unitOfWork.Ciudades.Add(ciudad);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostCiudad), new { id = ciudad.Id }, ciudad);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> PutCiudad(int id, [FromBody] CiudadDto dataUpdateCiudad)
    {
        if(dataUpdateCiudad == null) return NotFound();
        var ciudad = _mapper.Map<Ciudad>(dataUpdateCiudad);
        ciudad.Id = id;
        _unitOfWork.Ciudades.Update(ciudad);
        await _unitOfWork.SaveAsync();
        return dataUpdateCiudad;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCiudad(int id)
    {
        var ciudad = await _unitOfWork.Ciudades.GetByIdAsync(id);
        if(ciudad == null) return NotFound();
        _unitOfWork.Ciudades.Remove(ciudad);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CiudadDto>> GetByIdAsyncCiudad(int id)
    {
        var ciudad = await _unitOfWork.Ciudades.GetByIdAsync(id);
        if(ciudad == null) return NotFound(); 
        return _mapper.Map<CiudadDto>(ciudad);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CiudadDto>>> GetCiudadWhithPage([FromQuery] Params ciudadParams)
    {
        var ciudad = await _unitOfWork.Ciudades.GetAllAsync
        (
            ciudadParams.PageIndex,
            ciudadParams.PageSize,
            ciudadParams.Search
        );
        var lstCiudades = _mapper.Map<List<CiudadDto>>(ciudad.registros);
        return new Pager<CiudadDto>
        (
            lstCiudades,
            ciudad.totalRegistros,
            ciudadParams.PageIndex,
            ciudadParams.PageSize,
            ciudadParams.Search
        );
    }
}
