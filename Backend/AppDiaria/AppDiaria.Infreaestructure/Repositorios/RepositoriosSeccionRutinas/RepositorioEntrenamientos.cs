using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;
using AppDiaria.Infreaestructure.DB;
using Microsoft.EntityFrameworkCore;


namespace AppDiaria.Infreaestructure.Repositorios.RepositoriosSeccionRutinas;

public class RepositorioEntrenamientos:IRepositorioEntrenamiento
{
    protected readonly AppDiariaContext _context;
    public RepositorioEntrenamientos( AppDiariaContext context)
    {
        _context = context;
    }
    public void CrearEntrenamiento(Entrenamientos entrenamientos)
    {
            _context.Entrenamientos.Add(entrenamientos);
            _context.SaveChanges();  
    }

    public void EliminarEntrenamiento(int id)
    {
        var entrenamientosEliminar = _context.Entrenamientos.Where(rut => rut.Id == id).SingleOrDefault();
        if (entrenamientosEliminar != null)
        {
            _context.Remove(entrenamientosEliminar);
            _context.SaveChanges();
        }
    }

    public List<Entrenamientos> ListarEntrenamientos()
    {
       return _context.Entrenamientos
        .Include(e => e.EntrenamientoRutinas)
            .ThenInclude(er => er.Rutina)
        .ToList();
    }
    
    public List<Entrenamientos> ListarPorMes(DateOnly fecha)
    {
        var inicio = new DateOnly(fecha.Year, fecha.Month, 1);
        var fin = inicio.AddMonths(1);

        return _context.Entrenamientos
            .Include(e => e.EntrenamientoRutinas)
            .Where(e => e.Fecha >= inicio && e.Fecha < fin)
            .ToList();
    }
    
    public void ModificarEntrenamiento(Entrenamientos entrenamientos)
    {
        var entrenamientosExistente = _context.Entrenamientos.Find(entrenamientos.Id);
        if (entrenamientosExistente == null)
        {
            throw new Exception ();
        }
        entrenamientosExistente.Nombre= entrenamientos.Nombre;
        entrenamientosExistente.Fecha=entrenamientos.Fecha;
        entrenamientosExistente.UsuarioId=entrenamientos.UsuarioId;

         _context.SaveChanges();
    }
    public Entrenamientos? ObtenerPorId(int id)
    {
        return _context.Entrenamientos
            .Include(e => e.EntrenamientoRutinas)
            .ThenInclude(er => er.Rutina)
            .FirstOrDefault(e => e.Id == id);
    }
    public void GuardarCambios()
    {
        _context.SaveChanges();
    }


}
