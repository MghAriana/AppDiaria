using System;
using AppDiaria.Aplication.DTOS.Ejercicios;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;
using AppDiaria.Infreaestructure.DB;
using Microsoft.EntityFrameworkCore;


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

    public void GuardarCambios()
    {
        _context.SaveChanges();
    }

    public List<Rutina> ObtenerDisponibles(int? usuarioId)
    {
        return _context.Rutinas
        .Where(r => r.EsPredeterminada || r.UsuarioId == usuarioId)
        .Include(r => r.RutinaEjercicios)
            .ThenInclude(re => re.Ejercicio)
        .ToList();
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
            return _context.Rutinas
                .Include(r => r.RutinaEjercicios)
                    .ThenInclude(re => re.Ejercicio)
                .SingleOrDefault(r => r.Id == id);
    }

    public List<Rutina> ObtenerPredeterminadas()
    {
       return _context.Rutinas
        .Where(r => r.EsPredeterminada)
        .Include(r => r.RutinaEjercicios)
            .ThenInclude(re => re.Ejercicio)
        .ToList();
    }
}
