using System;
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
    public List<Tarea> ListarTareas()
    {
        return _repositorioTarea.ListarTareas();
    }
    public void CrearTarea(Tarea tarea)
    {
        _repositorioTarea.CrearTarea(tarea);
    }

    public void EliminarTarea(int id)
    {
        _repositorioTarea.EliminarTarea(id);
    }
    public void ModificarTarea(Tarea tarea)
    {
        _repositorioTarea.ModificarTarea(tarea);
    }
}
