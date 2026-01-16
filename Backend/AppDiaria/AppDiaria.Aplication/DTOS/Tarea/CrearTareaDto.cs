using System;

namespace AppDiaria.Aplication.DTOS.Tarea;

public class CrearTareaDto
{
    public String? Nombre { get; set; }
    public String? Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime Fin { get; set; }
    public int IdUsuario{get; set;}
}
