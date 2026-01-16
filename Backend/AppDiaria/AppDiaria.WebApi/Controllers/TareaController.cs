using AppDiaria.Aplication.DTOS.Tarea;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;
using AppDiaria.Aplication.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDiaria.Aplication.UseCases.Tareas;


namespace AppDiaria.WebApi.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    private readonly AgregarTareaUseCase _agregar;
    private readonly ListarTareaUseCase _listar;
    private readonly ModificarTareaUseCase _modificar;
    private readonly EliminarTareaUseCase _eliminar;

    public TareaController(
        AgregarTareaUseCase agregar,
        ListarTareaUseCase listar,
        ModificarTareaUseCase modificar,
        EliminarTareaUseCase eliminar)
    {
        _agregar = agregar;
        _listar = listar;
        _modificar = modificar;
        _eliminar = eliminar;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_listar.Ejecutar());
    }

    [HttpPost]
    public IActionResult Crear([FromBody] CrearTareaDto dto)
    {
        _agregar.Ejecutar(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ActualizarTareaDto dto)
    {
        _modificar.Ejecutar(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _eliminar.Ejecutar(id);
        return NoContent();
    }
}

}
