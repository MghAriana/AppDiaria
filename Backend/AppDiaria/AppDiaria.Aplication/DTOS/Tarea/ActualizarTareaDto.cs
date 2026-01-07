using System;

namespace AppDiaria.Aplication.DTOS.Tarea;

public class ActualizarTareaDto
{
     public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}
