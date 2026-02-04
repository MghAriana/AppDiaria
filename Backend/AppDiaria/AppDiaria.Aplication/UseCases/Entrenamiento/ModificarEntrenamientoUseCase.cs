using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;

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

   public void Ejecutar(ActualizarEntrenamientoDto dto)
{
    var entrenamiento = _repo.ObtenerPorId(dto.Id)
        ?? throw new Exception("Entrenamiento no existe");

    entrenamiento.Actualizar(dto.Nombre, dto.Fecha, dto.UsuarioId);

    _repo.ModificarEntrenamiento(entrenamiento);
}

}
