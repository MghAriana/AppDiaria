using System;
using AppDiaria.Aplication.DTOS.Tarea;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class ModificarTareaUseCase
{
    private readonly IRepositorioTarea _repo;
    private readonly ValidadorTarea _validador;

    public ModificarTareaUseCase(IRepositorioTarea repo, ValidadorTarea validador)
    {
        _repo = repo;
        _validador = validador;
    }

    public void Ejecutar(int id, ActualizarTareaDto dto)
    {
        var tarea = _repo.ObtenerPorId(id);
        if (tarea == null)
            throw new Exception("Tarea no encontrada");

        tarea.Actualizar(
            dto.Nombre,
            dto.Descripcion,
            dto.FechaInicio,
            dto.FechaFin
        );

        if (_validador.Validar(tarea, out var error))
            throw new Exception(error);

        _repo.ModificarTarea(tarea);
    }
}

