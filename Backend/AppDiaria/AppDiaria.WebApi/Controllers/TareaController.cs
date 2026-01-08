using AppDiaria.Aplication.DTOS.Tarea;
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
        public ActionResult Crear([FromBody] CrearTareaDto dto)
        {
            _tareaService.CrearTarea(dto);
            return Ok();
        }

       [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarTareaDto dto)
        {
            _tareaService.ActualizarTarea(id, dto);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            _tareaService.EliminarTarea(id);
            return NoContent();
        }
        }
}
