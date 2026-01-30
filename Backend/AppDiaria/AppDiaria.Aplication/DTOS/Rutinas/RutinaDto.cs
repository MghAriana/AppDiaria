using System;
using System.ComponentModel.DataAnnotations;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.DTOS.Rutinas;

public class RutinaDto
{
    [Key]
    public int Id{get; set;}
    public String? Nombre{get;set;}
    public string? Dia{get;set;}
    public string? Descripcion{get;set;}
    public List<Ejercicio> Ejercicios{get;set;} =new();

}
