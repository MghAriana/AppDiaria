using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;
using AppDiaria.Infreaestructure.DB;

namespace AppDiaria.Infreaestructure.Repositorios.RepositoriosSeccionRutinas;

public class RepositorioEjercicio:IRepositorioEjercicio
{
        protected readonly AppDiariaContext _context;
    public RepositorioEjercicio( AppDiariaContext context)
    {
        _context = context;
    }
    public void CrearEjercicio(Ejercicio ejercicio)
    {
            _context.Ejercicios.Add(ejercicio);
            _context.SaveChanges();  
    }

    public void EliminarEjercicio(int id)
    {
        var ejerciciosEliminar = _context.Ejercicios.Where(eje => eje.Id == id).SingleOrDefault();
        if (ejerciciosEliminar != null)
        {
            _context.Remove(ejerciciosEliminar);
            _context.SaveChanges();
        }
    }

    public List<Ejercicio> ListarEjercicios()
    {
        return _context.Ejercicios.ToList();
    }

    public void ModificarEjercicio(Ejercicio ejercicios)
    {
        var ejerciciosExistente = _context.Ejercicios.Find(ejercicios.Id);
        if (ejerciciosExistente == null)
        {
            throw new Exception ();
        }
        ejerciciosExistente.Nombre= ejercicios.Nombre;
        ejerciciosExistente.Descripcion=ejercicios.Descripcion;
        ejerciciosExistente.Series = ejercicios.Series;
        ejerciciosExistente.Repeticiones = ejercicios.Repeticiones;
        
         _context.SaveChanges();
    }
    public Ejercicio? ObtenerPorId(int id)
    {
        return _context.Ejercicios.SingleOrDefault(eje => eje.Id == id);
    }

}
