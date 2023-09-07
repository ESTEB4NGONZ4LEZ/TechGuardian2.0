
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class CompoCompuController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CompoCompuController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<CompoCompuDto>> Get()
    {
        var compoCompu = await _unitOfWork.CompoCompus.GetAllAsync();
        return _mapper.Map<List<CompoCompuDto>>(compoCompu);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CompoCompuDto>> Post(CompoCompuDto data)
    {
        var compoCompu = _mapper.Map<CompoCompu>(data);
        if(compoCompu == null) return BadRequest();
        _unitOfWork.CompoCompus.Add(compoCompu);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Post), new { id = compoCompu.Id }, compoCompu);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CompoCompuDto>> Put(int id, [FromBody] CompoCompuDto dataUpdate)
    {
        if(dataUpdate == null) return NotFound();
        var compoCompu = _mapper.Map<CompoCompu>(dataUpdate);
        compoCompu.Id = id;
        _unitOfWork.CompoCompus.Update(compoCompu);
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
        var compoCompu = await _unitOfWork.CompoCompus.GetByIdAsync(id);
        if(compoCompu == null) return NotFound();
        _unitOfWork.CompoCompus.Remove(compoCompu);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CompoCompuDto>> GetByIdAsync(int id)
    {
        var compoCompu = await _unitOfWork.CompoCompus.GetByIdAsync(id);
        if(compoCompu == null) return NotFound(); 
        return _mapper.Map<CompoCompuDto>(compoCompu);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CompoCompuDto>>> GetWhithPage([FromQuery] Params compoCompuParams)
    {
        var (totalRegistros, registros) = await _unitOfWork.CompoCompus.GetAllAsync
        (
            compoCompuParams.PageIndex,
            compoCompuParams.PageSize,
            compoCompuParams.Search
        );
        var lst = _mapper.Map<List<CompoCompuDto>>(registros);
        return new Pager<CompoCompuDto>
        (
            lst,
            totalRegistros,
            compoCompuParams.PageIndex,
            compoCompuParams.PageSize,
            compoCompuParams.Search
        );
    }
}
