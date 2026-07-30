using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Rutina
{
    [Key]
    public int Id{get; set;}
    public string Nombre{get;set;}
    public DayOfWeek Dia{get;set;}
    public string? Descripcion{get;set;}
    public bool EsPredeterminada { get; private set; }

    //para las relciones
    public ICollection<RutinaEjercicio> RutinaEjercicios { get; private set; } = new List<RutinaEjercicio>();
    public ICollection<EntrenamientoRutina> EntrenamientoRutinas { get; private set; } = new List<EntrenamientoRutina>();
    /*public int DuracionTotal{get;set;} //creo que no hace fata la variable porque se puede saber por algun metodo que recorra la lista de ejercicios y vaya sumando cada punto
    public int CantidadEjercicios{get;set;}
    public int CaloriasPerdidas{get;set;}
    public int RepeticionesTotales{get;set;} //hasta aca*/
    
    protected Rutina() { } // EF
    public Rutina(string nombre, DayOfWeek dia, string descripcion, bool esPredeterminada)
    {
        Nombre = nombre;
        Dia = dia;
        Descripcion = descripcion;
        EsPredeterminada = esPredeterminada;
        }
   
    public void Actualizar(String nombre, DayOfWeek dia, string descripcion)
    {
        Nombre = nombre;
        Dia = dia ;
        Descripcion = descripcion;
    }
   /*  public void AgregarEjercicio(Ejercicio ejercicio, int series, int repeticiones)
    {
        if (series < 1)
            throw new Exception("Debe tener al menos 1 serie");

        if (repeticiones < 5)
            throw new Exception("Debe tener al menos 5 repeticiones");

        var relacion = new RutinaEjercicio(this, ejercicio, series, repeticiones);
        RutinaEjercicios.Add(relacion);
    }*/
    public void AgregarEjercicio(Ejercicio ejercicio,int series, int repeticiones,int caloriasPorRepeticion)
    {
        if (series < 1)
            throw new Exception("Debe tener al menos 1 serie");

        if (repeticiones < 5)
            throw new Exception("Debe tener al menos 5 repeticiones");
        var relacion = new RutinaEjercicio(
            this,
            ejercicio,
            series,
            repeticiones,
            caloriasPorRepeticion
        );

        RutinaEjercicios.Add(relacion);
    }
    public void ModificarSeriesYRepeticiones(int ejercicioId,int series,int repeticiones)
    {
        var relacion = RutinaEjercicios
            .FirstOrDefault(re => re.EjercicioId == ejercicioId);

        if (relacion == null)
            throw new Exception("El ejercicio no está en la rutina");

        relacion.Actualizar(series, repeticiones);
    }
    public void EliminarEjercicio(int ejercicioId)
    {
        var relacion = RutinaEjercicios
            .FirstOrDefault(re => re.EjercicioId == ejercicioId);

        if (relacion == null)
            throw new Exception("El ejercicio no está en la rutina");

        RutinaEjercicios.Remove(relacion);
    }
}
