using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Aplication.UseCases.Recordatorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class RecordatorioController : ControllerBase
    {
        private readonly AgregarRecordatorioUseCase _agregar;
        private readonly ListarRecordatorioUseCase _listar;
        private readonly ModificarRecordatorioUseCase _modificar;
        private readonly EliminarRecordatorioUseCase _eliminar;
        private readonly ICurrentUserService _currentUser;

        public RecordatorioController(
            AgregarRecordatorioUseCase agregar,
            ListarRecordatorioUseCase listar,
            ModificarRecordatorioUseCase modificar,
            EliminarRecordatorioUseCase eliminar,
            ICurrentUserService currentUser)
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
            _currentUser = currentUser;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarioId = _currentUser.UsuarioId!.Value;

            var recordatorios = _listar.Ejecutar(usuarioId);

            return Ok(recordatorios);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearRecordatorioDto dto)
        {
            var usuarioId = _currentUser.UsuarioId!.Value;

            _agregar.Ejecutar(dto, usuarioId);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarRecordatorioDto dto)
        {
            var usuarioId = _currentUser.UsuarioId!.Value;

            _modificar.Ejecutar(id, usuarioId, dto);

            return Ok();
        }

       [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var usuarioId = _currentUser.UsuarioId!.Value;

            _eliminar.Ejecutar(id, usuarioId);

            return NoContent();
        }
    }
}
