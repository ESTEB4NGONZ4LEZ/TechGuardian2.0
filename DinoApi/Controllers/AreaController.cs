
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

public class AreaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AreaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<AreaDto>> GetArea()
    {
        var areas = await _unitOfWork.Areas.GetAllAsync();
        return _mapper.Map<List<AreaDto>>(areas);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AreaDto>> PostArea(AreaDto dataArea)
    {
        var area = _mapper.Map<Area>(dataArea);
        if(area == null) return BadRequest();
        _unitOfWork.Areas.Add(area);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostArea), new { id = area.Id }, area);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AreaDto>> PutArea(int id, [FromBody] AreaDto dataUpdateArea)
    {
        if(dataUpdateArea == null) return NotFound();
        var area = _mapper.Map<Area>(dataUpdateArea);
        area.Id = id;
        _unitOfWork.Areas.Update(area);
        await _unitOfWork.SaveAsync();
        return dataUpdateArea;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteArea(int id)
    {
        var area = await _unitOfWork.Areas.GetByIdAsync(id);
        if(area == null) return NotFound();
        _unitOfWork.Areas.Remove(area);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AreaDto>> GetByIdAsyncArea(int id)
    {
        var area = await _unitOfWork.Areas.GetByIdAsync(id);
        if(area == null) return NotFound(); 
        return _mapper.Map<AreaDto>(area);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<AreaDto>>> GetAreaWhithPage([FromQuery] Params areaParams)
    {
        var area = await _unitOfWork.Areas.GetAllAsync
        (
            areaParams.PageIndex,
            areaParams.PageSize,
            areaParams.Search
        );
        var lstAreas = _mapper.Map<List<AreaDto>>(area.registros);
        return new Pager<AreaDto>
        (
            lstAreas,
            area.totalRegistros,
            areaParams.PageIndex,
            areaParams.PageSize,
            areaParams.Search
        );
    }
}
