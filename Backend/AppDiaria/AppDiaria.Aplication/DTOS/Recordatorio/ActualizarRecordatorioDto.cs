using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Aplication.DTOS.Recordatorio;

public class ActualizarRecordatorioDto
{   public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechayHora { get; set; }
    public int UsuarioId {get;set;}

}
