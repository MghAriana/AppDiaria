using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;
        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }
        [HttpGet]
        public ActionResult<List<Tarea>> Get()
        {
            var tareas = _tareaService.ListarTareas();
            return Ok(tareas);
        }
                
        [HttpPost]
        public ActionResult Crear([FromBody] Tarea tarea)
        {
            _tareaService.CrearTarea(tarea);
            return CreatedAtAction(nameof(Get), new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id}")]
        public ActionResult Modificar(int id, [FromBody] Tarea tarea)
        {
            if (id != tarea.Id)
                return BadRequest("El id no coincide");

            _tareaService.ModificarTarea(tarea);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            _tareaService.EliminarTarea(id);
            return NoContent();
        }
    }
}
