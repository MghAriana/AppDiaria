using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class RutinaEjercicio
{
    [Key]
    public int Id { get; private set; }

    public int RutinaId { get; private set; }
    public Rutina Rutina { get; private set; }

    public int EjercicioId { get; private set; }
    public Ejercicio Ejercicio { get; private set; }

    public int Series { get; private set; }
    public int Repeticiones { get; private set; }
    public int CaloriasPorRepeticion { get; set; }

    protected RutinaEjercicio() { } 

    public RutinaEjercicio(Rutina rutina,Ejercicio ejercicio,int series, int repeticiones, int caloriasPorRepeticion)
    {
        if (series < 1)
            throw new Exception("Debe tener al menos 1 serie");

        if (repeticiones < 5)
            throw new Exception("Debe tener al menos 5 repeticiones");

        Rutina = rutina;
        RutinaId = rutina.Id;
        Ejercicio = ejercicio;
        EjercicioId = ejercicio.Id;
        Series = series;
        Repeticiones = repeticiones;
        CaloriasPorRepeticion = caloriasPorRepeticion;
        
    }

    public void Actualizar(int series, int repeticiones)
    {
        if (series < 1)
            throw new Exception("Debe tener al menos 1 serie");

        if (repeticiones < 5)
            throw new Exception("Debe tener al menos 5 repeticiones");

        Series = series;
        Repeticiones = repeticiones;
    }
    public int CaloriasTotales()
        => Series * Repeticiones * CaloriasPorRepeticion;
}
