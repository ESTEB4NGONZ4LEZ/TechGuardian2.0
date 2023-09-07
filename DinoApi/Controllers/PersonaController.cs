
using AutoMapper;
using DinoApi.Helpers;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<PersonaDto>> GetPersona()
    {
        var personas = await _unitOfWork.Personas.GetAllAsync();
        return _mapper.Map<List<PersonaDto>>(personas);   
    }

    [HttpPost]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> PostPersona(PersonaDto dataPersona)
    {
        var persona = _mapper.Map<Persona>(dataPersona);
        if(persona == null) return BadRequest();
        _unitOfWork.Personas.Add(persona);
        await _unitOfWork.SaveAsync();
        return CreatedAtAction(nameof(PostPersona), new { id = persona.Id }, persona);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> PutPersona(int id, [FromBody] PersonaDto dataUpdatePersona)
    {
        if(dataUpdatePersona == null) return NotFound();
        var persona = _mapper.Map<Persona>(dataUpdatePersona);
        persona.Id = id;
        _unitOfWork.Personas.Update(persona);
        await _unitOfWork.SaveAsync();
        return dataUpdatePersona;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeletePersona(int id)
    {
        var persona = await _unitOfWork.Personas.GetByIdAsync(id);
        if(persona == null) return NotFound();
        _unitOfWork.Personas.Remove(persona);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonaDto>> GetByIdAsyncPersona(int id)
    {
        var persona = await _unitOfWork.Personas.GetByIdAsync(id);
        if(persona == null) return NotFound(); 
        return _mapper.Map<PersonaDto>(persona);
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PersonaDto>>> GetPersonaWhithPage([FromQuery] Params personaParams)
    {
        var persona = await _unitOfWork.Personas.GetAllAsync
        (
            personaParams.PageIndex,
            personaParams.PageSize,
            personaParams.Search
        );
        var lstPersonas = _mapper.Map<List<PersonaDto>>(persona.registros);
        return new Pager<PersonaDto>
        (
            lstPersonas,
            persona.totalRegistros,
            personaParams.PageIndex,
            personaParams.PageSize,
            personaParams.Search
        );
    }
}
