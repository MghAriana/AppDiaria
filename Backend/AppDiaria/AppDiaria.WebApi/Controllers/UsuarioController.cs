using AppDiaria.Aplication.DTOS.Usuario;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Aplication.UseCases.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class UsuarioController : ControllerBase
    {
        private readonly AgregarUsuarioUseCase _crear;
        private readonly ListarUsuarioUseCase _listar;
        private readonly ObtenerUsuarioUseCase _obtener;
        private readonly EliminarUsuarioUseCase _eliminar;
        private readonly ICurrentUserService _currentUser;

        public UsuarioController(
            AgregarUsuarioUseCase crear,
            ListarUsuarioUseCase listar,
            ObtenerUsuarioUseCase obtener,
            EliminarUsuarioUseCase eliminar,
            ICurrentUserService currentUser)
        {
            _crear = crear;
            _listar = listar;
            _obtener = obtener;
            _eliminar = eliminar;
            _currentUser = currentUser;
        }

        // GET api/usuario
        [HttpGet]
        public IActionResult Listar()
        {
            var usuarios = _listar.Ejecutar();
            return Ok(usuarios);
        }

        // GET api/usuario/5
        [Authorize]
        [HttpGet("perfil")]
        public IActionResult Obtener()
        {
            var usuarioId = _currentUser.UsuarioId!.Value;

            var usuario = _obtener.Ejecutar(usuarioId);

            if (usuario == null)
                return NotFound("Usuario no encontrado");

            return Ok(usuario);
        }

        // POST api/usuario
        [HttpPost]
        public IActionResult Crear([FromBody] CrearUsuarioDto dto)
        {
            _crear.Ejecutar(dto);

            return Ok(new 
            { 
                mensaje = "Usuario creado correctamente" 
            });
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
         try
            {
                _eliminar.Ejecutar(id);
                return NoContent();
            }
            catch
            {
                return NotFound("Usuario no encontrado");
            }
        }
    }
}

