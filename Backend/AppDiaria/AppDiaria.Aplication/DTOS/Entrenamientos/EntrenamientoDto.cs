using System;
using System.ComponentModel.DataAnnotations;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.DTOS.Entrenamientos;

public class EntrenamientoDto
{
    [Key]
    public int Id{get; set;}
    public string? Nombre{get;set;}
    public DateOnly Fecha{get;set;}
    public Rutina Rutinas{get;set;}
    public int IdUsuario{get;set;}

}
