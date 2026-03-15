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
        var entrenamientosEliminar = _context.Entrenamientos.Find(id);
        if (entrenamientosEliminar != null)
        {
            _context.Entrenamientos.Remove(entrenamientosEliminar);
            _context.SaveChanges();
        }
    }

   public List<Entrenamientos> ListarEntrenamientos(int usuarioId)
    {
        return _context.Entrenamientos
            .Include(e => e.EntrenamientoRutinas)
                .ThenInclude(er => er.Rutina)
            .Where(e => e.UsuarioId == usuarioId)
            .ToList();
    }
    
    public List<Entrenamientos> ListarPorMes(int usuarioId, DateOnly fecha)
    {
        var inicio = new DateOnly(fecha.Year, fecha.Month, 1);
        var fin = inicio.AddMonths(1);

        return _context.Entrenamientos
            .Include(e => e.EntrenamientoRutinas)
                .ThenInclude(er => er.Rutina)
            .Where(e => e.UsuarioId == usuarioId &&
                        e.Fecha >= inicio &&
                        e.Fecha < fin)
            .ToList();
    }
    
    public void ModificarEntrenamiento(Entrenamientos entrenamiento)
    {
        _context.Entrenamientos.Update(entrenamiento);
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
