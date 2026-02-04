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
        private readonly ListarEntrenamientosPorFechaUseCase _listarporfecha;
        private readonly AgregarRutinaAEntrenamientoUseCase _agregarRutina;

        public EntrenamientosController(
            AgregarEntrenamientoUseCase agregar,
            ListarEntrenamientoUseCase listar,
            ModificarEntrenamientoUseCase modificar,
            EliminarEntrenamientoUseCase eliminar,
            ListarEntrenamientosPorFechaUseCase listarporfecha,
            AgregarRutinaAEntrenamientoUseCase agregarRutinaA)
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
            _listarporfecha= listarporfecha;
            _agregarRutina= agregarRutinaA;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entrenamientos = _listar.Ejecutar();
            return Ok(entrenamientos);
        }
        
        [HttpGet("mes")]
        public IActionResult ObtenerPorMes(DateOnly fecha)
        {
            var ejercicios = _listarporfecha.Ejecutar(fecha);
            return Ok(ejercicios);
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
            dto.Id = id;
            _modificar.Ejecutar(dto);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            _eliminar.Ejecutar(id);
            return NoContent();
        }
        
        [HttpPost("{entrenamientoId}/rutinas")]
        public IActionResult AgregarRutina(
            int entrenamientoId,
            [FromBody] AgregarRutinaAEntrenamientoDto dto)
        {
            _agregarRutina.Ejecutar(entrenamientoId, dto.RutinaId);
            return Ok();
        }


    }

}

