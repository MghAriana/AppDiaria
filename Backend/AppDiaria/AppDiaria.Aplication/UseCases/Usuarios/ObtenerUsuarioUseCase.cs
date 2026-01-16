using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class ObtenerUsuarioUseCase(IRepositorioUsuario repoUs)
{
    public Usuario Ejecutar(int id_Usuario)
    {
        return repoUs.ObtenerUsuario(id_Usuario);
    }
}
