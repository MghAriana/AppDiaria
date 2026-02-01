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

    public void Ejecutar(int id, ActualizarEntrenamientoDto dto)
    {
        var entrenamiento = _repo.ObtenerPorId(id);
        if (entrenamiento == null)
            throw new Exception("Entrenamiento no encontrado");

        entrenamiento.Actualizar(
            dto.Nombre,
            dto.Fecha,
            dto.UsuarioId
        );

        if (dto.Rutinas != null)
        {
            entrenamiento.Rutinas.Clear();

            foreach (var rutinaDto in dto.Rutinas)
            {
                var rutina = new Rutina(
                    rutinaDto.Nombre,
                    rutinaDto.Dia,
                    rutinaDto.Descripcion,
                    rutinaDto.Ejercicios.Select(e =>
                        new Ejercicio(
                            e.Nombre,
                            e.Descripcion,
                            e.Series,
                            e.Repeticiones
                        )
                    ).ToList()
                );

                entrenamiento.AgregarRutina(rutina);
            }
        }

        if (!_validador.Validar(entrenamiento, out var error))
            throw new Exception(error);

        _repo.ModificarEntrenamiento(entrenamiento);
    }

}
