using System;
using AppDiaria.Aplication.Interfaces.Login;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace AppDiaria.Infreaestructure.Services;

public class CurrentUserService:ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int? UsuarioId
    {
        get
        {
            var userId = _httpContextAccessor
                .HttpContext?
                .User?
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            if (int.TryParse(userId, out var id))
                return id;

            return null;
        }
    }

    public bool IsAuthenticated
    {
        get
        {
            return _httpContextAccessor
                .HttpContext?
                .User?
                .Identity?
                .IsAuthenticated ?? false;
        }
    }

  
}
