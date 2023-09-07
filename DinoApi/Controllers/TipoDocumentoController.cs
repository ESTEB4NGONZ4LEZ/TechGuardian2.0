
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class TipoDocumentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TipoDocumentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<TipoDocumentoDto>> Get()
    {
        var tipoDocumento = await _unitOfWork.TipoDocumentos.GetAllAsync();
        return _mapper.Map<List<TipoDocumentoDto>>(tipoDocumento);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoDocumentoDto>> Post(TipoDocumentoDto data)
    {
        var tipoDocumento = _mapper.Map<TipoDocumento>(data);
        if(tipoDocumento == null) return BadRequest();
        _unitOfWork.TipoDocumentos.Add(tipoDocumento);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(Post), new { id = tipoDocumento.Id }, tipoDocumento);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumentoDto>> Put(int id, [FromBody] TipoDocumentoDto dataUpdate)
    {
        if(dataUpdate == null) return NotFound();
        var tipoDocumento = _mapper.Map<TipoDocumento>(dataUpdate);
        tipoDocumento.Id = id;
        _unitOfWork.TipoDocumentos.Update(tipoDocumento);
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
        var tipoDocumento = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        if(tipoDocumento == null) return NotFound();
        _unitOfWork.TipoDocumentos.Remove(tipoDocumento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TipoDocumentoDto>> GetByIdAsync(int id)
    {
        var tipoDocumento = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        if(tipoDocumento == null) return NotFound(); 
        return _mapper.Map<TipoDocumentoDto>(tipoDocumento);
    }
}
