using System;

namespace AppDiaria.Aplication.DTOS.Usuario;

public class ActualizarUsuarioDto
{
    public String? Nombre{get;set;}
    public String? Email{get;set;}
    public DateTime FechaCreacion {get;set;}
}
