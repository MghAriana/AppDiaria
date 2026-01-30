using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class ModificarEntrenamientoUseCase
{
    private readonly IRepositorioEntrenamiento _repo;
    private readonly ValidadorEntrenamiento _validador;

    public ModificarEntrenamientoUseCase(IRepositorioEntrenamiento repo, ValidadorEntrenamiento validador)
    {
        _repo = repo;
        _validador = validador;
    }

    public void Ejecutar(int id, ActualizarEntrenamientoDto dto)
    {
        var entrenamiento = _repo.ObtenerPorId(id);
        if (entrenamiento == null)
            throw new Exception("Tarea no encontrada");

        entrenamiento.Actualizar(
            dto.Nombre,
            dto.Fecha,
            dto.IdUsuario
        );

        if (_validador.Validar(entrenamiento, out var error))
            throw new Exception(error);

        _repo.ModificarEntrenamiento(entrenamiento);
    }

}
