using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class ModificarUseCase(IRepositorioUsuario repositorioUsuario, ValidadorUsuario validador)
{
    public void Ejecutar(Usuario usuario)
    {
         if (!validador.Validador(usuario, out string MensajeError))
        {
            throw new Exception(MensajeError);
        }
        repositorioUsuario.ModificarUsuario(usuario);
    }
}
