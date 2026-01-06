using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;
using AppDiaria.Infreaestructure.DB;
using SQLitePCL;

namespace AppDiaria.Infreaestructure.Repositorios;

public class RepositorioTarea : IRepositorioTarea
{
    protected readonly AppDiariaContext _context;
    public RepositorioTarea( AppDiariaContext context)
    {
        _context = context;
    }
    public void CrearTarea(Tarea tarea)
    {
            _context.Tareas.Add(tarea);
            _context.SaveChanges();  
    }

    public void EliminarTarea(int id)
    {
        var tareaEliminar = _context.Tareas.Where(tar => tar.Id == id).SingleOrDefault();
        if (tareaEliminar != null)
        {
            _context.Remove(tareaEliminar);
            _context.SaveChanges();
        }
    }

    public List<Tarea> ListarTareas()
    {
        return _context.Tareas.ToList();
    }

    public void ModificarTarea(Tarea tarea)
    {
       /* var tareaExistente = _context.Tareas.Find(tarea.Id);
        if (tareaExistente != null)
        {
            throw new Exception ();
        }
        _context.Entry(tareaExistente).CurrentValues.SetValues(tarea);*/
         _context.SaveChanges();
    }
    public Tarea? ObtenerPorId(int id)
    {
        return _context.Tareas.FirstOrDefault(t => t.Id == id);
    }

}
