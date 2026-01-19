using System;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Ejercicio
{ 
    public int Id {get;private set;}
    public String? Nombre{get;set;}
    public String? Descripcion {get;set;}
    public int Series{get;set;}
    public int Repeticiones{get;set;}
    public int CaloriasPerdidas{get;set;}
    
    //public List<video> Video {get;set;}

    public Ejercicio(String? nombre, String? descripcion, int series, int repeticiones)
    {
        Nombre =nombre;
        Descripcion = descripcion;
        Series = series;
        Repeticiones = repeticiones;
        CaloriasPerdidas = 0;

    }

}
