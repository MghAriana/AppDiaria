using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class ListarEntrenamientoUseCase
{
    private readonly IRepositorioEntrenamiento _repo;
    private readonly ICurrentUserService _currentUser;

    public ListarEntrenamientoUseCase(IRepositorioEntrenamiento repo, ICurrentUserService currentUser)
    {
        _repo = repo;
        _currentUser = currentUser;
    }

   public List<EntrenamientoDto> Ejecutar()
    {
        var usuarioId = _currentUser.UsuarioId 
            ?? throw new Exception("Usuario no autenticado");

        var entrenamientos = _repo.ListarEntrenamientos(usuarioId);

        return entrenamientos.Select(e => new EntrenamientoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Fecha = e.Fecha,
            UsuarioId = e.UsuarioId
        }).ToList();
    }
}

