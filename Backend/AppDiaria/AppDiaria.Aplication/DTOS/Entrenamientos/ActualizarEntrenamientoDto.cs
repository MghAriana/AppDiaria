using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.DTOS.Entrenamientos;

public class ActualizarEntrenamientoDto
{
    public string? Nombre{get;set;}
    public DateOnly Fecha{get;set;}
    public Rutina? Rutinas{get;set;}
    public int IdUsuario{get;set;}

}
