using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Aplication.DTOS.Usuario;

public class UsuarioDto
{
    [Key]
    public int Id{get;set;}
    public String? Nombre{get;set;}
    public String? Email{get;set;}
    public DateTime FechaCreacion {get;set;}

}
