using System;

namespace AppDiaria.Aplication.DTOS.Ejercicios;

public class EjercicioDto
{
    public int Id {get; set;}
    public String? Nombre{get;set;}
    public String? Descripcion {get;set;}
    public int Series{get;set;}
    public int Repeticiones{get;set;}
    public int CaloriasPerdidas{get;set;}

}
