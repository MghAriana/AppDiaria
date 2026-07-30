using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class ListarTareaUseCase(IRepositorioTarea repoT)
{
    public List<Tarea> Ejecutar(int usuarioId)
    {
        return repoT.ListarTareas(usuarioId);
    }
}
