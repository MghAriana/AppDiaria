using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.UseCases.Entrenamiento;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers.ControllersSeccionRutinas
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrenamientosController : ControllerBase
    {
         private readonly AgregarEntrenamientoUseCase _agregar;
        private readonly ListarEntrenamientoUseCase _listar;
        private readonly ModificarEntrenamientoUseCase _modificar;
        private readonly EliminarEntrenamientoUseCase _eliminar;

        public EntrenamientosController(
            AgregarEntrenamientoUseCase agregar,
            ListarEntrenamientoUseCase listar,
            ModificarEntrenamientoUseCase modificar,
            EliminarEntrenamientoUseCase eliminar)
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entrenamientos = _listar.Ejecutar();
            return Ok(entrenamientos);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearEntrenamientoDto dto)
        {
            _agregar.Ejecutar(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarEntrenamientoDto dto)
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

