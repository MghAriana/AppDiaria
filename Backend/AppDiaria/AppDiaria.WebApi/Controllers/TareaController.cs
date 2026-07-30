using AppDiaria.Aplication.DTOS.Tarea;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;
using AppDiaria.Aplication.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDiaria.Aplication.UseCases.Tareas;
using Microsoft.AspNetCore.Authorization;
using AppDiaria.Aplication.Interfaces.Login;


namespace AppDiaria.WebApi.Controllers
{
[ApiController]
[Route("api/[controller]")]
[Authorize]

public class TareaController : ControllerBase
{
    private readonly AgregarTareaUseCase _agregar;
    private readonly ListarTareaUseCase _listar;
    private readonly ModificarTareaUseCase _modificar;
    private readonly EliminarTareaUseCase _eliminar;
    private readonly ICurrentUserService _currentUser;

    public TareaController(
        AgregarTareaUseCase agregar,
        ListarTareaUseCase listar,
        ModificarTareaUseCase modificar,
        EliminarTareaUseCase eliminar,
        ICurrentUserService currentUser)
    {
        _agregar = agregar;
        _listar = listar;
        _modificar = modificar;
        _eliminar = eliminar;
        _currentUser = currentUser;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarioId = _currentUser.UsuarioId!.Value;
        var tareas = _listar.Ejecutar(usuarioId);
        return Ok(tareas);
    }

    [HttpPost]
    public IActionResult Crear([FromBody] CrearTareaDto dto)
    {
        var usuarioId = _currentUser.UsuarioId!.Value;
        _agregar.Ejecutar(dto, usuarioId);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ActualizarTareaDto dto)
    {
        var usuarioId = _currentUser.UsuarioId!.Value;
        _modificar.Ejecutar(id, usuarioId,dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var usuarioId = _currentUser.UsuarioId!.Value;
        _eliminar.Ejecutar(id, usuarioId);
        return NoContent();
    }
}

}
