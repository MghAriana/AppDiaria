using System;
using System.ComponentModel.DataAnnotations;

namespace AppDiaria.Domain.Entidades;

public class Recordatorio
{
    [Key]
    public int Id { get; private set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechayHora { get; set; }

    protected Recordatorio() { }//lo usa EntityFramework 

    public Recordatorio( string? nombre, string? descripcion, DateTime hora)
    {
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.FechayHora = hora;
    }
    public void Actualizar(string nombre, string descripcion, DateTime Fyhora)
    {
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.FechayHora = Fyhora;
        
    }
}
