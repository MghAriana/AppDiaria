using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class ListarEntrenamientosPorFechaUseCase(IRepositorioEntrenamiento _repositorio, ICurrentUserService _currentUser)
{
   public List<EntrenamientoDto> Ejecutar(DateOnly fecha)
    {
        var usuarioId = _currentUser.UsuarioId!.Value;

        var entrenamientos = _repositorio.ListarPorMes(usuarioId, fecha);

        return entrenamientos.Select(e => new EntrenamientoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Fecha = e.Fecha,
            UsuarioId = e.UsuarioId,
            Rutinas = e.EntrenamientoRutinas
                .Select(er => new EntrenamientoRutinaDto
                {
                    RutinaId = er.RutinaId,
                    NombreRutina = er.Rutina.Nombre
                }).ToList()

        }).ToList();
    }
          
}
