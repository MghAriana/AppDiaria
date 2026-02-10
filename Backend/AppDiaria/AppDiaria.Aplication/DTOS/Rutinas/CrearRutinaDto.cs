using System;
using AppDiaria.Aplication.DTOS.Rutinas;

namespace AppDiaria.Aplication.DTOS.Rutinas;

public class CrearRutinaDto
{
 public string Nombre { get; set; }
    public DayOfWeek Dia { get; set; }
    public string? Descripcion { get; set; }
    public bool EsPredeterminada { get; set; }

    public List<AgregarEjercicioARutinaDto> Ejercicios { get; set; }
}
