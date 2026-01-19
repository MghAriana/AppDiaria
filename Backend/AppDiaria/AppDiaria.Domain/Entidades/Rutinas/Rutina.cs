using System;
using System.Collections;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Rutina
{
    public int Id{get;private set;}
    public String? Nombre{get;set;}
    public string? Dia{get;set;}
    public string? Descripcion{get;set;}
    public int DuracionTotal{get;set;} //creo que no hace fata la variable porque se puede saber por algun metodo
    public int CantidadEjercicios{get;set;}
    public int CaloriasPerdidas{get;set;}
    public int RepeticionesTotales{get;set;} //hasta aca
    public List<Ejercicio> Ejercicios{get;set;}

    public Rutina(String? nombre, string dia, string desc)
    {
        Nombre = nombre;
        Dia = dia;
        Descripcion = desc;
        Ejercicios = [];
        
    }
}
