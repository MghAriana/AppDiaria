using System;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Rutina
{
    public int Id{get;private set;}
    public String? Nombre{get;set;}
    public DateOnly FechaInicio{get;set;}
    public DateOnly FechaFin{get;set;}
    //private List<Ejercicio> Ejercicios;

    public Rutina(String? nombre,DateOnly fechaInicio,DateOnly fechaFin)
    {
        Nombre = nombre;
        FechaInicio= fechaInicio;
        FechaFin = fechaFin;
    }
}
