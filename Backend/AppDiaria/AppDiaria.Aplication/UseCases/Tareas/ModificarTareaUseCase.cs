using System;
using AppDiaria.Aplication.DTOS.Tarea;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class ModificarTareaUseCase(IRepositorioTarea repo, ValidadorTarea validador)
{
    
    public void Ejecutar(int id,int usuarioId, ActualizarTareaDto dto)
    {
        var tarea = repo.ObtenerPorId(id);
        if (tarea == null)
            throw new Exception("Tarea no encontrada");
        if (tarea.UsuarioId != usuarioId)
            throw new Exception("No autorizado");

        tarea.Actualizar(
            dto.Nombre,
            dto.Descripcion,
            dto.FechaInicio,
            dto.FechaFin
        );

        if (validador.Validar(tarea, out var error))
            throw new Exception(error);

        repo.ModificarTarea(tarea);
    }
}

