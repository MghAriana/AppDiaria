using AppDiaria.Aplication.DTOS.Ejercicios;
using AppDiaria.Aplication.UseCases.Ejercicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers.ControllersSeccionRutinas
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        private readonly AgregarEjercicioUseCase _agregar;
        private readonly ListarEjercicioUseCase _listar;
        private readonly ModificarEjercicioUseCase _modificar;
        private readonly EliminarEjercicioUseCase _eliminar;

        public EjercicioController(
            AgregarEjercicioUseCase agregar,
            ListarEjercicioUseCase listar,
            ModificarEjercicioUseCase modificar,
            EliminarEjercicioUseCase eliminar)
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ejercicios = _listar.Ejecutar();
            return Ok(ejercicios);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearEjercicioDto dto)
        {
            _agregar.Ejecutar(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarEjercicioDto dto)
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

