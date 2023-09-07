
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ArlController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ArlController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<ArlDto>> GetArl()
    {
        var arl = await _unitOfWork.Arl.GetAllAsync();
        return _mapper.Map<List<ArlDto>>(arl);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArlDto>> PostArl(ArlDto dataArl)
    {
        var arl = _mapper.Map<Arl>(dataArl);
        if(arl == null) return BadRequest();
        _unitOfWork.Arl.Add(arl);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostArl), new { id = arl.Id }, arl);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ArlDto>> PutArl(int id, [FromBody] ArlDto dataUpdateArl)
    {
        if(dataUpdateArl == null) return NotFound();
        var arl = _mapper.Map<Arl>(dataUpdateArl);
        arl.Id = id;
        _unitOfWork.Arl.Update(arl);
        await _unitOfWork.SaveAsync();
        return dataUpdateArl;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteArl(int id)
    {
        var pais = await _unitOfWork.Arl.GetByIdAsync(id);
        if(pais == null) return NotFound();
        _unitOfWork.Arl.Remove(pais);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArlDto>> GetByIdAsyncArl(int id)
    {
        var arl = await _unitOfWork.Arl.GetByIdAsync(id);
        if(arl == null) return NotFound(); 
        return _mapper.Map<ArlDto>(arl);
    }
}
