using System;
using AppDiaria.Aplication.Interfaces;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class EliminarUseCase(IRepositorioTarea repositorioTarea)
{
    public void Ejecutar(int id)
    {
        repositorioTarea.EliminarTarea(id);
    }
}
