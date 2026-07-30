using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios.Login;

public class LoginUseCase(IRepositorioUsuario _repo, IJwtService _token)
{
   public string Ejecutar(string email, string password)
{
    var usuario = _repo.ObtenerPorEmail(email);

    if (usuario == null)
        throw new Exception("Usuario no encontrado");

    bool passwordCorrecta = BCrypt.Net.BCrypt.Verify(
        password,
        usuario.PasswordHash
    );

    if (!passwordCorrecta)
        throw new Exception("Credenciales inválidas");

    return _token.GenerarToken(usuario.Id, usuario.Email ?? string.Empty);
}

}
