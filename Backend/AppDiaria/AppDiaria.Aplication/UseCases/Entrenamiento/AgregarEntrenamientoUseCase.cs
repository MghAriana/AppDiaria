using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;


namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class AgregarEntrenamientoUseCase
{
    private readonly IRepositorioEntrenamiento _repo;
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly ValidadorEntrenamiento _validador;
    private readonly ICurrentUserService _currentUser;
    

    public AgregarEntrenamientoUseCase(
        IRepositorioEntrenamiento repo,
        IRepositorioUsuario repoUsuario,
        ValidadorEntrenamiento validador,
        ICurrentUserService currentUser
        )
    {
        _repo = repo;
        _repoUsuario = repoUsuario;
        _validador = validador;
        _currentUser = currentUser;

    }

    public void Ejecutar(CrearEntrenamientoDto dto)
    {
        var usuarioId = _currentUser.UsuarioId!.Value;

        if (!_repoUsuario.Existe(usuarioId))
            throw new Exception("Usuario no existe");

        var entrenamiento = new Entrenamientos(
            dto.Nombre,
            dto.Fecha,
            usuarioId
        );

        if (!_validador.Validar(entrenamiento, out var error))
            throw new Exception(error);

        _repo.CrearEntrenamiento(entrenamiento);
    }


}
