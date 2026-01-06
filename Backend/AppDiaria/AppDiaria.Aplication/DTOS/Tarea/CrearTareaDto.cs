using System;

namespace AppDiaria.Aplication.DTOS.Tarea;

public class CrearTareaDto
{
     public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime Fin { get; set; }
}
