using System;
using AppDiaria.Aplication.DTOS.Tarea;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Services;

public class TareaService:ITareaService
{
    private readonly IRepositorioTarea _repositorioTarea;
    public TareaService(IRepositorioTarea repositorioTarea)
    {
        _repositorioTarea = repositorioTarea;
    }
           public List<TareaDto> ListarTareas()
        {
            return _repositorioTarea.ListarTareas()
                .Select(t => new TareaDto
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Descripcion = t.Descripcion,
                    FechaInicio = t.Fecha,
                    FechaFin = t.Fin
                })
                .ToList();
        }

        public void CrearTarea(CrearTareaDto dto)
        {
            var tarea = new Tarea(
                dto.Nombre,
                dto.Descripcion,
                dto.Fecha,
                dto.Fin
            );

            _repositorioTarea.CrearTarea(tarea);
        }

    public void ActualizarTarea(ActualizarTareaDto dto)
    {
    var tarea = _repositorioTarea.ObtenerPorId(dto.Id);

    if (tarea == null)
        throw new Exception("Tarea no encontrada");

    tarea.Actualizar(
        dto.Nombre,
        dto.Descripcion,
        dto.FechaInicio,
        dto.FechaFin
    );

    _repositorioTarea.ModificarTarea(tarea);
}

        public void EliminarTarea(int id)
        {
            var tarea = _repositorioTarea.ObtenerPorId(id);

            if (tarea == null)
                throw new Exception("Tarea no encontrada");

            _repositorioTarea.EliminarTarea(id);

        }
}

