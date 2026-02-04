using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;


namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class AgregarEntrenamientoUseCase
{
    private readonly IRepositorioEntrenamiento _repo;
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly ValidadorEntrenamiento _validador;
    

    public AgregarEntrenamientoUseCase(
        IRepositorioEntrenamiento repo,
        IRepositorioUsuario repoUsuario,
        ValidadorEntrenamiento validador
        )
    {
        _repo = repo;
        _repoUsuario = repoUsuario;
        _validador = validador;
    }

    public void Ejecutar(CrearEntrenamientoDto dto)
    {
        if (!_repoUsuario.Existe(dto.UsuarioId))
            throw new Exception("Usuario no existe");

        var entrenamiento = new Entrenamientos(
            dto.Nombre,
            dto.Fecha,
            dto.UsuarioId
        );

        if (!_validador.Validar(entrenamiento, out var error))
            throw new Exception(error);

        _repo.CrearEntrenamiento(entrenamiento);
    }


}
