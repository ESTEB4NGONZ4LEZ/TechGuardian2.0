
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class LugarController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public LugarController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<LugarDto>> GetLugar()
    {
        var lugar = await _unitOfWork.Lugares.GetAllAsync();
        return _mapper.Map<List<LugarDto>>(lugar);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LugarDto>> PostLugar(LugarDto dataLugar)
    {
        var lugar = _mapper.Map<Lugar>(dataLugar);
        if(lugar == null) return BadRequest();
        _unitOfWork.Lugares.Add(lugar);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostLugar), new { id = lugar.Id }, lugar);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LugarDto>> PutLugar(int id, [FromBody] LugarDto dataUpdateLugar)
    {
        if(dataUpdateLugar == null) return NotFound();
        var lugar = _mapper.Map<Lugar>(dataUpdateLugar);
        lugar.Id = id;
        _unitOfWork.Lugares.Update(lugar);
        await _unitOfWork.SaveAsync();
        return dataUpdateLugar;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteLugar(int id)
    {
        var lugar = await _unitOfWork.Lugares.GetByIdAsync(id);
        if(lugar == null) return NotFound();
        _unitOfWork.Lugares.Remove(lugar);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LugarDto>> GetByIdAsyncLugar(int id)
    {
        var lugar = await _unitOfWork.Lugares.GetByIdAsync(id);
        if(lugar == null) return NotFound(); 
        return _mapper.Map<LugarDto>(lugar);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<LugarDto>>> GetLugarWhithPage([FromQuery] Params lugarParams)
    {
        var lugar = await _unitOfWork.Insidencias.GetAllAsync
        (
            lugarParams.PageIndex,
            lugarParams.PageSize,
            lugarParams.Search
        );
        var lstLugares = _mapper.Map<List<LugarDto>>(lugar.registros);
        return new Pager<LugarDto>
        (
            lstLugares,
            lugar.totalRegistros,
            lugarParams.PageIndex,
            lugarParams.PageSize,
            lugarParams.Search
        );
    }
}
