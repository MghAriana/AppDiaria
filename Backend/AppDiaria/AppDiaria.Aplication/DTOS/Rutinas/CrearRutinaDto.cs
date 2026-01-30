using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.DTOS.Rutinas;

public class CrearRutinaDto
{
    public String? Nombre{get;set;}
    public string? Dia{get;set;}
    public string? Descripcion{get;set;}
    public List<Ejercicio> Ejercicios{get;set;} =new();
}
