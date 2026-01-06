using System;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Interfaces;

public interface IRepositorioTarea
{
    public void CrearTarea(Tarea tarea);
    public List<Tarea> ListarTareas();
   void EliminarTarea(int id);

    public void ModificarTarea(Tarea tarea);
    Tarea? ObtenerPorId(int id);

}
