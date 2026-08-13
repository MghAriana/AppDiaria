using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.UseCases.RutinaEjercicio;
using AppDiaria.Aplication.UseCases.Rutinas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers.ControllersSeccionRutinas
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        private readonly AgregarRutinaUseCase _agregar;
        private readonly ListarRutinaUseCase _listar;//publicas
        private readonly ListarMisRutinasUseCase _listarMisRutinas;//privadas
        private readonly ModificarRutinaUseCase _modificar;
        private readonly EliminarRutinaUseCase _eliminar;
        private readonly AgregarEjercicioARutinaUseCase _agregarEjercicioARutinaUseCase;
        private readonly QuitarEjercicioDeRutinaUseCase _quitarEjercicio;

        public RutinaController(
            AgregarRutinaUseCase agregar,
            ListarRutinaUseCase listar, 
            ListarMisRutinasUseCase listarMisRutinas,
            ModificarRutinaUseCase modificar,
            EliminarRutinaUseCase eliminar,
            AgregarEjercicioARutinaUseCase agregarEjercicioARutinaUseCase,
             QuitarEjercicioDeRutinaUseCase quitarEjercicio)
        {
            _agregar = agregar;
            _listar = listar;
            _listarMisRutinas = listarMisRutinas;
            _modificar = modificar;
            _eliminar = eliminar;
            _agregarEjercicioARutinaUseCase = agregarEjercicioARutinaUseCase;
            _quitarEjercicio = quitarEjercicio;
        }
        [HttpGet("rutinas-predeterminadas")]
        public IActionResult GetPublicas()
        {
            var rutinas = _listar.Ejecutar();
            return Ok(rutinas);
        }

        [Authorize]
        [HttpGet("mis-rutinas")]
        public IActionResult GetMisRutinas()
        {
            var resultado = _listarMisRutinas.Ejecutar();
            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult CrearRutina(CrearRutinaDto dto)
        {
            var rutinaId = _agregar.Ejecutar(dto);
            return Ok(rutinaId);
        }

        [HttpPost("{rutinaId}/ejercicios")]
        public IActionResult AgregarEjercicios(int rutinaId,AgregarEjercicioARutinaDto dto)
        {
            dto.RutinaId = rutinaId;
            _agregarEjercicioARutinaUseCase.Ejecutar(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarRutinaDto dto)
        {
            _modificar.Ejecutar(id, dto);
            return Ok();
        }  
        [Authorize] 
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            _eliminar.Ejecutar(id);
            return NoContent();
        }
        [HttpDelete("{rutinaId}/ejercicios/{ejercicioId}")]
        public IActionResult QuitarEjercicio(
            int rutinaId,
            int ejercicioId)
        {
            var dto = new QuitarEjercicioDeRutinaDto
            {
                RutinaId = rutinaId,
                EjercicioId = ejercicioId
            };

            _quitarEjercicio.Ejecutar(dto);
            return NoContent();
        }
        
    }
}
