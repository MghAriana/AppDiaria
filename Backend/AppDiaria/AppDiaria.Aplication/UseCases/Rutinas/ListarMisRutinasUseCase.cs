using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.DTOS.Rutinas.RutinaEjercicio;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Interfaces.Login;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class ListarMisRutinasUseCase
{

    private readonly IRepositorioRutina _repo;
    private readonly ICurrentUserService _currentUser;

    public ListarMisRutinasUseCase(
        IRepositorioRutina repo,
        ICurrentUserService currentUser)
    {
        _repo = repo;
        _currentUser = currentUser;
    }

    public List<RutinaDto> Ejecutar()
    {
        int usuarioId = _currentUser.UsuarioId
            ?? throw new UnauthorizedAccessException();

        var rutinas = _repo.ObtenerDisponibles(usuarioId);

        return rutinas.Select(r => new RutinaDto
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Dia = r.Dia.ToString(),
            Descripcion = r.Descripcion,
            Ejercicios = r.RutinaEjercicios.Select(re => new RutinaEjercicioDto
            {
                EjercicioId = re.EjercicioId,
                Nombre = re.Ejercicio.Nombre,
                Series = re.Series,
                Repeticiones = re.Repeticiones
            }).ToList()
        }).ToList();
    }
}

