
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class EpsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public EpsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<EpsDto>> GetEps()
    {
        var eps = await _unitOfWork.Eps.GetAllAsync();
        return _mapper.Map<List<EpsDto>>(eps);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EpsDto>> PostEps(EpsDto dataEps)
    {
        var eps = _mapper.Map<Eps>(dataEps);
        if(eps == null) return BadRequest();
        _unitOfWork.Eps.Add(eps);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostEps), new { id = eps.Id }, eps);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EpsDto>> PutEps(int id, [FromBody] EpsDto dataUpdateEps)
    {
        if(dataUpdateEps == null) return NotFound();
        var eps = _mapper.Map<Eps>(dataUpdateEps);
        eps.Id = id;
        _unitOfWork.Eps.Update(eps);
        await _unitOfWork.SaveAsync();
        return dataUpdateEps;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteEps(int id)
    {
        var eps = await _unitOfWork.Eps.GetByIdAsync(id);
        if(eps == null) return NotFound();
        _unitOfWork.Eps.Remove(eps);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EpsDto>> GetByIdAsyncEps(int id)
    {
        var eps = await _unitOfWork.Eps.GetByIdAsync(id);
        if(eps == null) return NotFound(); 
        return _mapper.Map<EpsDto>(eps);
    }
}
