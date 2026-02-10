using System;

namespace AppDiaria.Aplication.DTOS.Rutinas;

public class AgregarEjercicioARutinaDto
{
    public int RutinaId { get; set; }
    public List<AgregarEjercicioARutinaItemDto> Ejercicios { get; set; } = new();
}
