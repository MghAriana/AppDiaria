using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class EliminarUsuarioUseCase(IRepositorioUsuario repositorioUsuario)
{
    public void Ejecutar(int id)
    {
        repositorioUsuario.EliminarUsuario(id);
    }
}
