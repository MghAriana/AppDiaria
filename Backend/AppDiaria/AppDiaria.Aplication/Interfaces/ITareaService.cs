using System;
using AppDiaria.Domain.Entidades;
using AppDiaria.Aplication.DTOS.Tarea;


namespace AppDiaria.Aplication.Interfaces;

public interface ITareaService
{
        List<TareaDto> ListarTareas();
        void CrearTarea(CrearTareaDto dto);
        void ActualizarTarea(int id,ActualizarTareaDto dto);
        void EliminarTarea(int id);
}
