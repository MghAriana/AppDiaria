using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Ejercicio
{
    [Key]
    public int Id { get; private set; }

    public string Nombre { get; private set; } = null!;
    public string? Descripcion { get; private set; }

    // Relacion con Rutina
    public List<RutinaEjercicio> RutinaEjercicios { get; private set; } = new();

    protected Ejercicio() { } // EF

    public Ejercicio(string nombre, string? descripcion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new Exception("El nombre del ejercicio es obligatorio");

        Nombre = nombre;
        Descripcion = descripcion;
    }

    public void Actualizar(string nombre, string? descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }
}