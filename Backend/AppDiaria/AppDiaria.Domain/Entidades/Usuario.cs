using System;
using System.ComponentModel.DataAnnotations;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Domain.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Email { get; set; }
  //  public string? Contraseña { get; set; }
    public DateTime FechaCreacion {get;private set;}
    //aca deberia haber una lista de permisos de usuario
    public List<Tarea> Tareas { get; set; } = new();
    public List<Recordatorio> Recordatorios { get; set; } = new();
    public List<Entrenamientos> Entrenamientos { get; set; } = new();

    public Usuario() { }

    public Usuario( string nombre, string email)
    {

        Nombre = nombre;
        Email = email;
        //Contraseña = contraseña;
        FechaCreacion= DateTime.UtcNow;
    }
    public void Actualizar(string nombre,string email)
    {
        Nombre = nombre;
        Email = email; 
    }

     /*  public override string ToString(){
        string aux="";
        aux+= $"Usuario Actual: {this.Nombre}  ";
        return aux;
    }*/

}
