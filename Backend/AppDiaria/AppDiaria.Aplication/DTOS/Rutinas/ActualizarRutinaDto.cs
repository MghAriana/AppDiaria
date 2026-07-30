using System;
using AppDiaria.Aplication.DTOS.Ejercicios;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.DTOS.Rutinas;

public class ActualizarRutinaDto
{
    public String? Nombre{get;set;}
    public DayOfWeek Dia{get;set;}
    public string? Descripcion{get;set;}
    public bool EsPredeterminada { get; set; }
    public List<CrearEjercicioDto> Ejercicios { get; set; } = new();

}
