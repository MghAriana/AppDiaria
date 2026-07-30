using System;

namespace AppDiaria.Aplication.DTOS.Usuario.Login;

public class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;

}
