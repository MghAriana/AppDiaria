using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Rutina
{
    [Key]
    public int Id{get; set;}
    public string? Nombre{get;set;}
    public string? Dia{get;set;}
    public string? Descripcion{get;set;}
    public List<Ejercicio> Ejercicios{get;set;} 
    /*public int DuracionTotal{get;set;} //creo que no hace fata la variable porque se puede saber por algun metodo que recorra la lista de ejercicios y vaya sumando cada punto
    public int CantidadEjercicios{get;set;}
    public int CaloriasPerdidas{get;set;}
    public int RepeticionesTotales{get;set;} //hasta aca*/
    
    protected Rutina() { } // EF
    public Rutina(string? nombre, string dia, string descripcion, List<Ejercicio> ejercicios)
    {
        Nombre = nombre;
        Dia = dia;
        Descripcion = descripcion;
        Ejercicios = ejercicios;
        
        
    }
   
    public void Actualizar(String nombre, string dia, string descripcion)
    {
        Nombre = nombre;
        Dia = dia ;
        Descripcion = descripcion;
    }
}
