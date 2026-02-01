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
    public int IdUsuario {get;set;}
    public Usuario? Usuario{get;set;}

    protected Recordatorio() { }//lo usa EntityFramework 

    public Recordatorio( string? nombre, string? descripcion, DateTime hora , int idUsuario)
    {
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.FechayHora = hora;
        IdUsuario = idUsuario;
    }
    public void Actualizar(string nombre, string descripcion, DateTime Fyhora)
    {
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.FechayHora = Fyhora;
        
    }
}
