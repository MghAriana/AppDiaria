using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordatorioController : ControllerBase
    {
        private readonly IRecordatorioService _recordatorioService;
        public RecordatorioController(IRecordatorioService recordatorioService)
        {
            _recordatorioService = recordatorioService;
        }
        [HttpGet]
        public ActionResult<List<Recordatorio>> Get()
        {
            var recordatorios = _recordatorioService.ListarRecordatorio();
            return Ok(recordatorios);
        }
                
        [HttpPost]
        public ActionResult Crear([FromBody] CrearRecordatorioDto dto)
        {
            _recordatorioService.CrearRecordatorio(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarRecordatorioDto dto)
        {
            _recordatorioService.ActualizarRecordatorio(id, dto);
            return Ok();
        }

            [HttpDelete("{id}")]
        public ActionResult Eliminar(int id)
        {
            _recordatorioService.EliminarRecordatorio(id);
            return NoContent();
        }
        }
}

