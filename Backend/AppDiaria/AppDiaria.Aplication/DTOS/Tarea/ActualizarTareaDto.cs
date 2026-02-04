using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Aplication.DTOS.Tarea;

public class ActualizarTareaDto
{  
     public String? Nombre { get; set; }
    public String? Descripcion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int UsuarioId {get;set;}
}
