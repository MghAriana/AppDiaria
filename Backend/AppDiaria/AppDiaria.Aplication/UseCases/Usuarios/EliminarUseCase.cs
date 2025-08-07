using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class EliminarUseCase(IRepositorioUsuario repositorioUsuario)
{
    public void Ejecutar(int id)
    {
        repositorioUsuario.EliminarUsuario(id);
    }
}
