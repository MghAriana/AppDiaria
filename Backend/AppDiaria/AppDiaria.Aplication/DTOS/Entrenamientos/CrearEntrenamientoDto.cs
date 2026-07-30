using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.DTOS.Entrenamientos;

public class CrearEntrenamientoDto
{
    public string? Nombre{get;set;}
    public DateOnly Fecha{get;set;}
    public List<RutinaDto> Rutinas { get; set; } = new();
    public int UsuarioId {get;set;}

}
