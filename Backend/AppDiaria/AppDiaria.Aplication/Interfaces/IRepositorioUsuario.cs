using System;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Interfaces;

public interface IRepositorioUsuario
{
    public void AgregarUsuario(Usuario usuario);
    public List<Usuario> ListarUsuarios();
    public void EliminarUsuario(int id);
    public void ModificarUsuario(Usuario usuario);
    public Usuario ObtenerUsuario(int id_Usuario);
    public bool ExisteEmail(string email);
}
