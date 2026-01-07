using System;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Ejercicio
{ 
    public int Id {get;private set;}
    public String? Nombre{get;set;}
    public TimeOnly Duracion{get;set;}
    public String? Descripcion {get;set;}
    //public List<video> Video {get;set;}

    public Ejercicio(String? nombre,TimeOnly dur , String? descripcion)
    {
        Nombre =nombre;
        Duracion = dur;
        Descripcion = descripcion;
    }

}
