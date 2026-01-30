using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class ListarEntrenamientoUseCase(IRepositorioEntrenamiento repositorioEntrenamiento)
{
    public List<Entrenamientos> Ejecutar()
    {
        return repositorioEntrenamiento.ListarEntrenamientos();
    }
}

