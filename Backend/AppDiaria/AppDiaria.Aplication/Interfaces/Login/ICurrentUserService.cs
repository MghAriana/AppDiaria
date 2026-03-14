using System;

namespace AppDiaria.Aplication.Interfaces.Login;

public interface ICurrentUserService
{
    int? UsuarioId { get; }
    bool IsAuthenticated { get; }
    
}
