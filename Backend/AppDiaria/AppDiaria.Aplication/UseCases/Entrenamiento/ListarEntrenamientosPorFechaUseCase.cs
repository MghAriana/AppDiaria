using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class ListarEntrenamientosPorFechaUseCase(IRepositorioEntrenamiento repositorioEntrenamiento)
{
    public List<Entrenamientos> Ejecutar(DateOnly fecha)
    {
       return repositorioEntrenamiento
            .ListarEntrenamientos()
            .Where(e => e.Fecha.Month == fecha.Month &&
                        e.Fecha.Year == fecha.Year)
            .ToList();
    }
}
