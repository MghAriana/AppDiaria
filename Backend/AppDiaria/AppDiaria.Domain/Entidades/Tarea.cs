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
    public DateTime FechaInicio{get;set;}
    public DateTime FechaFin{get;set;}
    private Estado _estado;
    public int IdUsuario{get;private set;}


    public Tarea( string nombre, string descripcion,/*0List<Item> lista ,*/ DateTime inicio, DateTime duracion,int idUsuario)
    {
        
        this.Nombre = nombre;
        this.Descripcion = descripcion;
       // this._item = lista;
        this.FechaInicio = inicio; //DateTime.Today;
        this.FechaFin = duracion;
        this.IdUsuario= idUsuario;
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
        return fecha >= FechaInicio && fecha <= FechaFin;
    }

    
    public void Actualizar(string nombre, string descripcion, DateTime fecha, DateTime fin)
    {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fecha;
            FechaFin = fin;
    }

   /* public void agregarItem(String item) //deberia crear una clase item??
    {
        _item.Add(item);
    }*/

    
}
