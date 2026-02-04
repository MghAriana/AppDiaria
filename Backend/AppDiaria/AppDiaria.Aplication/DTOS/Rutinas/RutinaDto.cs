using System;
using System.ComponentModel.DataAnnotations;
using AppDiaria.Aplication.DTOS.Ejercicios;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.DTOS.Rutinas;

public class RutinaDto
{
    [Key]
    public int Id{get; set;}
    public String? Nombre{get;set;}
    public string? Dia{get;set;}
    public string? Descripcion{get;set;}
    public List<CrearEjercicioDto> Ejercicios{get;set;} =new();

}
