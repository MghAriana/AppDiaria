using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class ListarUseCase(IRepositorioTarea repoT)
{
    public List<Tarea> Ejecutar()
    {
        return repoT.ListarTareas();
    }
}
