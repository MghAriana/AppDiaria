using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class AgregarUseCase(IRepositorioUsuario repositorioUsuario, ValidadorUsuario validadorUsuario)
{
    public void Ejecutar(Usuario usuario)
    {
        if (!validadorUsuario.Validador(usuario, out string MensajeError))
        {
            throw new Exception(MensajeError);
        }
        repositorioUsuario.AgregarUsuario(usuario);
    }
}
