using System;
using System.Data.Common;

namespace AppDiaria.Domain.Entidades;

public class Tarea
{
    public int Id { get; }
    private string? _nombre;
    private string? _descripcion;
    private List<string>? _item;
    private DateTime _fecha;
    private DateTime _fin;
    private Estado _estado;


    public Tarea(int id, string? nombre, string? descripcion, List<string> item, DateTime inicio, DateTime duracion)
    {
        this.Id = id;
        this._nombre = nombre;
        this._descripcion = descripcion;
        this._item = item;
        this._fecha = inicio; //DateTime.Today;
        this._fin = duracion;
        this._estado = Estado.Pendiente;
    }
    public String? getNombre()
    {
        return this._nombre;
    }
    public void setNombre(String nombre)
    {
        this._nombre = nombre;
    }
    public String? getDescripcion()
    {
        return _descripcion;
    }
    public void setDescripcion(String campo)
    {
        this._descripcion = campo;
    }
    public void Iniciar()
    {
        _estado = Estado.Pendiente;
    }

    public void Finalizar()
    {
        if (_estado != Estado.Pendiente)
        {
            throw new Exception("no se pueden finalizar tareas que no esten en estado Pendiente");
        }
        _estado = Estado.Completa;
    }

    public void NoRealizada(DateTime fecha)
    {
        if (estaEnRango(fecha))
        {
            throw new Exception("La tarea esta pendiente");
        }
        _estado = Estado.Incompleta;
    }


    public bool estaEnRango(DateTime fecha)
    {
        return _fecha < fecha || fecha > _fin;
    }

    public void agregarItem(String item) //deberia crear una clase item??
    {
        this._item.Add(item);
    }

    
}
