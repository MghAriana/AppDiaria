using System;

namespace AppDiaria.Aplication.DTOS.Rutinas;

public class ModificarSeriesRepsDto
{
    public int RutinaId { get; set; }
    public int EjercicioId { get; set; }
    public int Series { get; set; }
    public int Repeticiones { get; set; }

}
