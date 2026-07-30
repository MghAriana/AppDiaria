using System;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class EntrenamientoRutina
{
  public int EntrenamientoId { get; private set; }
    public Entrenamientos Entrenamiento { get; private set; } = null!;

    public int RutinaId { get; private set; }
    public Rutina Rutina { get; private set; } = null!;

    protected EntrenamientoRutina() { } 

    public EntrenamientoRutina(Entrenamientos entrenamiento, Rutina rutina)
    {
        Entrenamiento = entrenamiento;
        Rutina = rutina;
        EntrenamientoId = entrenamiento.Id;
        RutinaId = rutina.Id;
    }
}
