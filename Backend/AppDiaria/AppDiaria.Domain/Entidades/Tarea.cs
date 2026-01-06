using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace AppDiaria.Domain.Entidades;

public class Tarea
{
    [Key]
    public int Id { get; private set; }
    public string Nombre{get;set;} = string.Empty;
    public string Descripcion{get;set;} = string.Empty;
    //private List<Item>? _item = [];
    public DateTime Fecha{get;set;}
    public DateTime Fin{get;set;}
    private Estado _estado;


    public Tarea( string nombre, string descripcion,/*0List<Item> lista ,*/ DateTime inicio, DateTime duracion)
    {
        
        this.Nombre = nombre;
        this.Descripcion = descripcion;
       // this._item = lista;
        this.Fecha = inicio; //DateTime.Today;
        this.Fin = duracion;
        this._estado = Estado.Pendiente;
    }
    //contructor vacio para EntityFramework
    protected Tarea(){}
   
   /* public List<Item> listarItem()
    {
        return _item.getItem();
    }*/
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
        if (EstaEnRango(fecha))
        {
            throw new Exception("La tarea esta pendiente");
        }
        _estado = Estado.Incompleta;
    }


  
    public bool EstaEnRango(DateTime fecha)
    {
        return fecha >= Fecha && fecha <= Fin;
    }

    
    public void Actualizar(string nombre, string descripcion, DateTime fecha, DateTime fin)
    {
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
            Fin = fin;
    }

   /* public void agregarItem(String item) //deberia crear una clase item??
    {
        _item.Add(item);
    }*/

    
}
