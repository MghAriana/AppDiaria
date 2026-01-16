using System;

namespace AppDiaria.Aplication.DTOS.Recordatorio;

public class CrearRecordatorioDto
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechayHora { get; set; }
    public int IdUsuario{get;set;}
}
