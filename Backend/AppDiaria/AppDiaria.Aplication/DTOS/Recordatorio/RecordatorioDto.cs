using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Aplication.DTOS.Recordatorio;

public class RecordatorioDto
{
    [Key]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechayHora { get; set; }
}
