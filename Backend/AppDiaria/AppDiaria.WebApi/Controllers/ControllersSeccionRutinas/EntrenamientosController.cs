using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Aplication.UseCases.Entrenamiento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers.ControllersSeccionRutinas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class EntrenamientosController : ControllerBase
    {
        private readonly AgregarEntrenamientoUseCase _agregar;
        private readonly ListarEntrenamientoUseCase _listar;
        private readonly ModificarEntrenamientoUseCase _modificar;
        private readonly EliminarEntrenamientoUseCase _eliminar;
        private readonly ListarEntrenamientosPorFechaUseCase _listarporfecha;
        private readonly AgregarRutinaAEntrenamientoUseCase _agregarRutina;
        private readonly ICurrentUserService _currentUser;

        public EntrenamientosController(
            AgregarEntrenamientoUseCase agregar,
            ListarEntrenamientoUseCase listar,
            ModificarEntrenamientoUseCase modificar,
            EliminarEntrenamientoUseCase eliminar,
            ListarEntrenamientosPorFechaUseCase listarporfecha,
            AgregarRutinaAEntrenamientoUseCase agregarRutinaA,
            ICurrentUserService currentUser
            )
        {
            _agregar = agregar;
            _listar = listar;
            _modificar = modificar;
            _eliminar = eliminar;
            _listarporfecha= listarporfecha;
            _agregarRutina= agregarRutinaA;
            _currentUser = currentUser;
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
            var entrenamientos = _listarporfecha.Ejecutar(fecha);
            return Ok(entrenamientos);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] CrearEntrenamientoDto dto)
        {
            var usuarioId = _currentUser.UsuarioId!.Value;
            _agregar.Ejecutar(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarEntrenamientoDto dto)
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
        
        [HttpPost("{entrenamientoId}/rutinas")]
        public IActionResult AgregarRutina(
            int entrenamientoId,
            [FromBody] AgregarRutinaAEntrenamientoDto dto)
        {
            var usuarioId = _currentUser.UsuarioId!.Value;
            _agregarRutina.Ejecutar(entrenamientoId, dto.RutinaId);
            return Ok();
        }


    }

}

