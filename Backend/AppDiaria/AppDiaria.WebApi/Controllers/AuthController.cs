using AppDiaria.Aplication.DTOS.Usuario.Login;
using AppDiaria.Aplication.UseCases.Usuarios.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDiaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
     private readonly LoginUseCase _login;

    public AuthController(LoginUseCase login)
    {
        _login = login;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        try
        {
            var token = _login.Ejecutar(dto.Email, dto.Contraseña);

            return Ok(new
            {
                token = token
            });
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}    
}
