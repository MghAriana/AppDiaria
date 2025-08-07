using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;
using AppDiaria.Infreaestructure.DB;

namespace AppDiaria.Infreaestructure.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    protected readonly AppDiariaContext _context;
    public RepositorioUsuario(AppDiariaContext context)
    {
        _context = context;
    }
    public void AgregarUsuario(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public void EliminarUsuario(int id)
    {
        var usuarioBorrar = _context.Usuarios.
                            Where(us => us.Id == id).SingleOrDefault();
        if (usuarioBorrar == null)
        {
            throw new Exception();
        }
        _context.Remove(usuarioBorrar);
        _context.SaveChanges();
    }

    public bool ExisteEmail(string email)
    {
         return _context.Usuarios.Any(u => u.Email == email);
    }

    public List<Usuario> ListarUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public void ModificarUsuario(Usuario usuario)
    {
        var usuarioExistente = _context.Usuarios.Find(usuario.Id);
        if (usuarioExistente == null)
        {
            throw new Exception();
        }
        _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
        _context.SaveChanges();
    }

    public Usuario ObtenerUsuario(int id_Usuario)
    {
       var usu = _context.Usuarios.Find(id_Usuario);
        return usu!;
    }
}
