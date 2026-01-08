using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Aplication.DTOS.Tarea;

public class TareaDto
{
    [Key]
    public int Id { get; set; }
    public String? Nombre { get; set; }
    public String? Descripcion { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}
