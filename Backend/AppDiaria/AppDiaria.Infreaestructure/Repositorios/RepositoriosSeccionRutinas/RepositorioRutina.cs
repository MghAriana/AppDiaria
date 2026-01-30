using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;
using AppDiaria.Infreaestructure.DB;


namespace AppDiaria.Infreaestructure.Repositorios.RepositoriosSeccionRutinas;

public class RepositorioRutina : IRepositorioRutina
{
    protected readonly AppDiariaContext _context;
    public RepositorioRutina( AppDiariaContext context)
    {
        _context = context;
    }
    public void CrearRutina(Rutina rutina)
    {
            _context.Rutinas.Add(rutina);
            _context.SaveChanges();  
    }

    public void EliminarRutina(int id)
    {
        var rutinaEliminar = _context.Rutinas.Where(rut => rut.Id == id).SingleOrDefault();
        if (rutinaEliminar != null)
        {
            _context.Remove(rutinaEliminar);
            _context.SaveChanges();
        }
    }

    public List<Rutina> ListarRutinas()
    {
        return _context.Rutinas.ToList();
    }

    public void ModificarRutina(Rutina rutina)
    {
        var rutinaExistente = _context.Rutinas.Find(rutina.Id);
        if (rutinaExistente == null)
        {
            throw new Exception ();
        }
        rutinaExistente.Nombre= rutina.Nombre;
        rutinaExistente.Descripcion= rutina.Descripcion;
        rutinaExistente.Dia = rutina.Dia;
        
         _context.SaveChanges();
    }
    public Rutina? ObtnerPorId(int id)
    {
        return _context.Rutinas.SingleOrDefault(rut => rut.Id == id);
    }
}
