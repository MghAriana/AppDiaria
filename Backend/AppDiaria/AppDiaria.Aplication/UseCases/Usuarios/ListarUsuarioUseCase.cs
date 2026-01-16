using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class ListarUsuarioUseCase(IRepositorioUsuario repoUs)
{
    public List<Usuario> Ejecutar()
    {
        return repoUs.ListarUsuarios();
    }
}
