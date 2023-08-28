
using AutoMapper;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<AreaDto>> Get()
    {
        var areas = await _unitOfWork.Areas.GetAllAsync();
        return _mapper.Map<List<AreaDto>>(areas);   
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AreaDto>> GetByIdAsync(int id)
    {
        var area = await _unitOfWork.Areas.GetByIdAsync(id);
        if(area == null) return NotFound(); 
        return _mapper.Map<AreaDto>(area);
    }
}
