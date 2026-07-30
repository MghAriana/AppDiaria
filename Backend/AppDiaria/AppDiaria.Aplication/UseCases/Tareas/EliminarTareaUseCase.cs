using System;
using AppDiaria.Aplication.Interfaces;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class EliminarTareaUseCase(IRepositorioTarea repositorioTarea)
{
    public void Ejecutar(int id, int usuarioId)
    {
        var tarea = repositorioTarea.ObtenerPorId(id);
        if (tarea == null)
            throw new Exception("Tarea no encontrada");
        if (tarea.UsuarioId != usuarioId)
            throw new Exception("No autorizado");
            
        repositorioTarea.EliminarTarea(id);
    }
}
