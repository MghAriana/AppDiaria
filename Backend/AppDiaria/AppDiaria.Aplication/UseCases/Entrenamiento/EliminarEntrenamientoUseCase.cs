using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class EliminarEntrenamientoUseCase(IRepositorioEntrenamiento repositorio)
{
    public void Ejecutar(int id)
    {
        repositorio.EliminarEntrenamiento(id);
    }

}
