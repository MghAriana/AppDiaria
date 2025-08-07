using System;
using System.Data.Common;

namespace AppDiaria.Domain.Entidades;

public class Tarea
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public List<string>? Item { get; set; }
    public DateTime Inicio{ get; set; }
    public TimeSpan Duracion { get; set; }
    

    public Tarea()
    {

    }
    public Tarea(int id, string nombre, string descripcion, List<string> item, DateTime inicio, TimeSpan duracion)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.Item = item;
        this.Inicio = inicio;
        this.Duracion = duracion;
    }
}
