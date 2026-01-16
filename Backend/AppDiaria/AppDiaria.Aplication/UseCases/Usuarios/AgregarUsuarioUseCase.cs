using System;
using AppDiaria.Aplication.DTOS.Usuario;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class AgregarUsuarioUseCase
{
    private readonly IRepositorioUsuario _repo;

    public AgregarUsuarioUseCase(IRepositorioUsuario repo)
    {
        _repo = repo;
    }

    public void Ejecutar(CrearUsuarioDto dto)
    {
        var usuario = new Usuario(
            dto.Nombre,
            dto.Email
        );

        _repo.AgregarUsuario(usuario);
    }
}
