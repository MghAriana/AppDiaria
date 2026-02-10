using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.UseCases.RutinaEjercicio;
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
        private readonly AgregarEjercicioARutinaUseCase _agregarEjercicioARutinaUseCase;
        private readonly QuitarEjercicioDeRutinaUseCase _quitarEjercicio;

        public RutinaController(
            AgregarRutinaUseCase agregar,
            ListarRutinaUseCase listar,
            ModificarRutinaUseCase modificar,
            EliminarRutinaUseCase eliminar,
            AgregarEjercicioARutinaUseCase agregarEjercicioARutinaUseCase,
             QuitarEjercicioDeRutinaUseCase quitarEjercicio)
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
            _agregarEjercicioARutinaUseCase = agregarEjercicioARutinaUseCase;
            _quitarEjercicio = quitarEjercicio;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var rutinas = _listar.Ejecutar();
            return Ok(rutinas);
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
