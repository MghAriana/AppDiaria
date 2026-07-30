using System;
using System.Security.Claims;
using System.Text;
using AppDiaria.Aplication.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


namespace AppDiaria.Infreaestructure.Services;

public class JwtService:IJwtService
{
    private readonly string _key;

    public JwtService(IConfiguration configuration)
    {
        _key = configuration["Jwt:Key"];
    }

    public string GenerarToken(int usuarioId, string email)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
            new Claim(ClaimTypes.Email, email)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_key)
        );

        var credenciales = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credenciales
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
