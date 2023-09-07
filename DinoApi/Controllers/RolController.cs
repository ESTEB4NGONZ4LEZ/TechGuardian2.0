
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class RolController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<RolDto>> GetRol()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<List<RolDto>>(roles);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> PostRol(RolDto dataRol)
    {
        var rol = _mapper.Map<Rol>(dataRol);
        if(rol == null) return BadRequest();
        _unitOfWork.Roles.Add(rol);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostRol), new { id = rol.Id }, rol);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDto>> PutRol(int id, [FromBody] RolDto dataUpdateRol)
    {
        if(dataUpdateRol == null) return NotFound();
        var rol = _mapper.Map<Rol>(dataUpdateRol);
        rol.Id = id;
        _unitOfWork.Roles.Update(rol);
        await _unitOfWork.SaveAsync();
        return dataUpdateRol;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteRol(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if(rol == null) return NotFound();
        _unitOfWork.Roles.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> GetByIdAsyncRol(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if(rol == null) return NotFound(); 
        return _mapper.Map<RolDto>(rol);
    }
}
