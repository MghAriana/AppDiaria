using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class ListarEntrenamientoUseCase
{
    private readonly IRepositorioEntrenamiento _repo;

    public ListarEntrenamientoUseCase(IRepositorioEntrenamiento repo)
    {
        _repo = repo;
    }

    public List<EntrenamientoDto> Ejecutar()
    {
        var entrenamientos = _repo.ListarEntrenamientos();

        return entrenamientos.Select(e => new EntrenamientoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Fecha = e.Fecha,
            Rutinas = e.EntrenamientoRutinas
                .Select(er => new RutinaDto
                {
                    Id = er.Rutina.Id,
                    Nombre = er.Rutina.Nombre
                })
                .ToList()
        }).ToList();
    }
}

