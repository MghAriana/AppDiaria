using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.UseCases.Rutinas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers.ControllersSeccionRutinas
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        private readonly AgregarRutinaUseCase _agregar;
        private readonly ListarRutinaUseCase _listar;
        private readonly ModificarRutinaUseCase _modificar;
        private readonly EliminarRutinaUseCase _eliminar;

        public RutinaController(
            AgregarRutinaUseCase agregar,
            ListarRutinaUseCase listar,
            ModificarRutinaUseCase modificar,
            EliminarRutinaUseCase eliminar)
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var rutinas = _listar.Ejecutar();
            return Ok(rutinas);
        }
        [HttpPost]
        public IActionResult Crear([FromBody] CrearRutinaDto dto)
        {
            _agregar.Ejecutar(dto);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarRutinaDto dto)
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
