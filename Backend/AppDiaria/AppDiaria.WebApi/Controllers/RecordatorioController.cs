using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.UseCases.Recordatorios;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordatorioController : ControllerBase
    {
        private readonly AgregarRecordatorioUseCase _agregar;
        private readonly ListarRecordatorioUseCase _listar;
        private readonly ModificarRecordatorioUseCase _modificar;
        private readonly EliminarRecordatorioUseCase _eliminar;

        public RecordatorioController(
            AgregarRecordatorioUseCase agregar,
            ListarRecordatorioUseCase listar,
            ModificarRecordatorioUseCase modificar,
            EliminarRecordatorioUseCase eliminar)
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var recordatorios = _listar.Ejecutar();
            return Ok(recordatorios);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearRecordatorioDto dto)
        {
            _agregar.Ejecutar(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarRecordatorioDto dto)
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
