
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class TipoEmailController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TipoEmailController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TipoEmailDto>> Get()
    {
        var tipoEmail = await _unitOfWork.TipoEmails.GetAllAsync();
        return _mapper.Map<List<TipoEmailDto>>(tipoEmail);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEmailDto>> Post(TipoEmailDto data)
    {
        var tipoEmail = _mapper.Map<TipoEmail>(data);
        if(tipoEmail == null) return BadRequest();
        _unitOfWork.TipoEmails.Add(tipoEmail);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Post), new { id = tipoEmail.Id }, tipoEmail);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoEmailDto>> Put(int id, [FromBody] TipoEmailDto dataUpdate)
    {
        if(dataUpdate == null) return NotFound();
        var tipoEmail = _mapper.Map<TipoEmail>(dataUpdate);
        tipoEmail.Id = id;
        _unitOfWork.TipoEmails.Update(tipoEmail);
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
        var tipoEmail = await _unitOfWork.TipoEmails.GetByIdAsync(id);
        if(tipoEmail == null) return NotFound();
        _unitOfWork.TipoEmails.Remove(tipoEmail);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoEmailDto>> GetByIdAsync(int id)
    {
        var tipoEmail = await _unitOfWork.TipoEmails.GetByIdAsync(id);
        if(tipoEmail == null) return NotFound(); 
        return _mapper.Map<TipoEmailDto>(tipoEmail);
    }
}
