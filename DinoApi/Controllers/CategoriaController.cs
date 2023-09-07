
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class CategoriaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<CategoriaDto>> GetCategoria()
    {
        var categorias = await _unitOfWork.Categorias.GetAllAsync();
        return _mapper.Map<List<CategoriaDto>>(categorias);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> PostCategoria(CategoriaDto dataCategoria)
    {
        var categoria = _mapper.Map<Categoria>(dataCategoria);
        if(categoria == null) return BadRequest();
        _unitOfWork.Categorias.Add(categoria);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostCategoria), new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> PutCategoria(int id, [FromBody] CategoriaDto dataUpdateCategoria)
    {
        if(dataUpdateCategoria == null) return NotFound();
        var categoria = _mapper.Map<Categoria>(dataUpdateCategoria);
        categoria.Id = id;
        _unitOfWork.Categorias.Update(categoria);
        await _unitOfWork.SaveAsync();
        return dataUpdateCategoria;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteCategoria(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
        if(categoria == null) return NotFound();
        _unitOfWork.Categorias.Remove(categoria);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> GetByIdAsyncCategoria(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
        if(categoria == null) return NotFound(); 
        return _mapper.Map<CategoriaDto>(categoria);
    }
}
