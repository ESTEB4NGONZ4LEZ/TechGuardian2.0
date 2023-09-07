
using AutoMapper;
using DinoApi.Dtos;
using DinoApi.Dtos.JWT;
using DinoApi.Services;
using Dominio.Entities;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinoApi.Controllers;

public class UsuarioController : BaseApiController
{
    private readonly IUserServices _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UsuarioController(IUserServices userService, IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        _userService = userService;
        this._unitOfWork = _unitOfWork;
        this._mapper = _mapper;
    }

    [HttpGet]
    [Authorize]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<List<UsuarioDto>> GetUsuario()
    {
        var usuario = await _unitOfWork.Usuarios.GetAllAsync();
        return _mapper.Map<List<UsuarioDto>>(usuario);   
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(RegisterUsuarioDto dataUser)
    {
        var registration = await _userService.RegisterUserAsync(dataUser);
        return Ok(registration);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginDto dataUser)
    {
        var login = await _userService.LoginAsync(dataUser);
        return Ok(login);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsuarioDto>> PutUsuario(int id, [FromBody] UsuarioDto dataUpdate)
    {
        if(dataUpdate == null) return NotFound();
        var usuario = _mapper.Map<Usuario>(dataUpdate);
        usuario.Id = id;
        _unitOfWork.Usuarios.Update(usuario);
        await _unitOfWork.SaveAsync();
        return dataUpdate;
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador, Gerente")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUsuario(int id)
    {
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if(usuario == null) return NotFound();
        _unitOfWork.Usuarios.Remove(usuario);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> GetUsuarioByIdAsyncU(int id)
    {
        var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if(usuario == null) return NotFound(); 
        return _mapper.Map<UsuarioDto>(usuario);
    }
}
