using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Entrenamientos
{
    [Key]
    public int Id{get; set;}
    public string? Nombre{get;set;}
    public DateOnly Fecha{get;set;}
    public List<Rutina> Rutinas { get; set; } = new(); //mas adelante ver si es ICollection
    public int UsuarioId{get;set;}
    public Usuario? Usuario{get;set;}

    protected Entrenamientos(){}//ef
    public Entrenamientos(string nombre, DateOnly fecha, int UsuarioId)
    {
        Nombre= nombre;
        Fecha=fecha;
        this.UsuarioId=UsuarioId;
    }
    
    public void AgregarRutina(Rutina rutina)
    {
        Rutinas.Add(rutina);
    }
    public void Actualizar(string nombre, DateOnly fecha, int id)
    {
        Nombre= nombre;
        Fecha=fecha;
        UsuarioId=id;
    }

}
