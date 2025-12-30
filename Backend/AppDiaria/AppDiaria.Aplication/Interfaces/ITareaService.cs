using System;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Interfaces;

public interface ITareaService
{
    List<Tarea> ListarTareas();
     void CrearTarea(Tarea tarea);
    void EliminarTarea(int id);
    void ModificarTarea(Tarea tarea);
}
