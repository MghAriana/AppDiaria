using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;
using AppDiaria.Infreaestructure.DB;
using SQLitePCL;

namespace AppDiaria.Infreaestructure.Repositorios;

public class RepositorioRecordatorio : IRepositorioRecordatorio
{
    protected readonly AppDiariaContext _context;
    public RepositorioRecordatorio(AppDiariaContext context)
    {
        _context = context;
    }
    public void CrearRecordatorio(Recordatorio recordatorio)
    {
        //var existe = _context.Recordatorios.Any(rec => rec.Id == recordatorio.Id);
        //if (!existe)

        _context.Recordatorios.Add(recordatorio);
        _context.SaveChanges();

    }

    public void EliminarRecordatorio(int id)
    {
        var recEliminar = _context.Recordatorios.Where(rec => rec.Id == id).SingleOrDefault();
        if (recEliminar == null)
        {
            throw new Exception();
        }
        _context.Remove(recEliminar);
        _context.SaveChanges();
    }

    public List<Recordatorio> ListarRecordatorios()
    {
        return _context.Recordatorios.ToList();
    }

    public void ModificarRecordatorio(Recordatorio recordatorio)
    {
        var existeRecordatorio = _context.Recordatorios.Find(recordatorio.Id);
        if (existeRecordatorio == null)
        {
            throw new Exception();
        }
        _context.Entry(existeRecordatorio).CurrentValues.SetValues(recordatorio);
        _context.SaveChanges();
    }
    
}
