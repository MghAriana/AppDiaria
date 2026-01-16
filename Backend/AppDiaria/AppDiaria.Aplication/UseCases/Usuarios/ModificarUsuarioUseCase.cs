using System;
using AppDiaria.Aplication.DTOS.Usuario;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class ModificarUsuarioUseCase
{
    private readonly IRepositorioUsuario _repo;
    private readonly ValidadorUsuario _validador;
    public ModificarUsuarioUseCase(IRepositorioUsuario repo, ValidadorUsuario validador)
    {
        _repo = repo;
        _validador = validador;
    }
    public void Ejecutar(int id, ActualizarUsuarioDto dto)
    {
        var usuario =_repo.ObtenerUsuario(id);

        usuario.Actualizar(
            dto.Nombre,
            dto.Email
        );
         if (!_validador.Validador(usuario, out var MensajeError))
        {
            throw new Exception(MensajeError);
        }
        _repo.ModificarUsuario(usuario);
    }
}
