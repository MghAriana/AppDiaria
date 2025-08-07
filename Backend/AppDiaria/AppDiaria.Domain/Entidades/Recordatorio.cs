using System;

namespace AppDiaria.Domain.Entidades;

public class Recordatorio
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public TimeOnly Hora { get; set; }

    public Recordatorio() { }

    public Recordatorio(int id, string nombre, string descripcion, TimeOnly hora)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.Hora = hora;
    }
}
