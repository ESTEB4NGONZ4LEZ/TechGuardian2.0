
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class TipoTelefonoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TipoTelefonoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TipoTelefonoDto>> Get()
    {
        var tipoTelefono = await _unitOfWork.TipoTelefonos.GetAllAsync();
        return _mapper.Map<List<TipoTelefonoDto>>(tipoTelefono);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoTelefonoDto>> Post(TipoTelefonoDto data)
    {
        var tipoTelefono = _mapper.Map<TipoTelefono>(data);
        if(tipoTelefono == null) return BadRequest();
        _unitOfWork.TipoTelefonos.Add(tipoTelefono);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Post), new { id = tipoTelefono.Id }, tipoTelefono);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoTelefonoDto>> Put(int id, [FromBody] TipoTelefonoDto dataUpdate)
    {
        if(dataUpdate == null) return NotFound();
        var tipoTelefono = _mapper.Map<TipoTelefono>(dataUpdate);
        tipoTelefono.Id = id;
        _unitOfWork.TipoTelefonos.Update(tipoTelefono);
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
        var tipoTelefono = await _unitOfWork.TipoTelefonos.GetByIdAsync(id);
        if(tipoTelefono == null) return NotFound();
        _unitOfWork.TipoTelefonos.Remove(tipoTelefono);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoTelefonoDto>> GetByIdAsync(int id)
    {
        var tipoTelefono = await _unitOfWork.TipoTelefonos.GetByIdAsync(id);
        if(tipoTelefono == null) return NotFound(); 
        return _mapper.Map<TipoTelefonoDto>(tipoTelefono);
    }
}
