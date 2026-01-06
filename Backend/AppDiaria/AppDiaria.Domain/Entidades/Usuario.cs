using System;

namespace AppDiaria.Domain.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Email { get; set; }
    public string? Contraseña { get; set; }
    //aca deberia haber una lista de permisos de usuario

    public Usuario() { }

    public Usuario(int id, string nombre, string email, string contraseña)
    {
        Id = id;
        Nombre = nombre;
        Email = email;
        Contraseña = contraseña;
    }
       public override string ToString(){
        string aux="";
        aux+= $"Usuario Actual: {this.Nombre}  ";
        return aux;
    }
}
