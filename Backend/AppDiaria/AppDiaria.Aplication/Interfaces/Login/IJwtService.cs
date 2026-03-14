using System;

namespace AppDiaria.Aplication.Interfaces;

public interface IJwtService
{
    string GenerarToken(int usuarioId, string nombre);
}
