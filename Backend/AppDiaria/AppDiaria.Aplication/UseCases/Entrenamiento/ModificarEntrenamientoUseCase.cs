using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class ModificarEntrenamientoUseCase
{
    private readonly IRepositorioEntrenamiento _repo;
    private readonly ValidadorEntrenamiento _validador;
    private readonly ICurrentUserService _currentUser;

    public ModificarEntrenamientoUseCase(IRepositorioEntrenamiento repo, ValidadorEntrenamiento validador, ICurrentUserService currentUser)
    {
        _repo = repo;
        _validador = validador;
        _currentUser = currentUser;
    }

   public void Ejecutar(int id, ActualizarEntrenamientoDto dto)
{
    var entrenamiento = _repo.ObtenerPorId(id)
            ?? throw new Exception("Entrenamiento no existe");

        if (entrenamiento.UsuarioId != _currentUser.UsuarioId)
            throw new Exception("No autorizado");

        entrenamiento.Actualizar(dto.Nombre, dto.Fecha);

        if (!_validador.Validar(entrenamiento, out var error))
            throw new Exception(error);

        _repo.ModificarEntrenamiento(entrenamiento);
}

}
