using System;
using AppDiaria.Aplication.DTOS.Ejercicios;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;

namespace AppDiaria.Aplication.UseCases.Ejercicios;

public class ModificarEjercicioUseCase
{
    private readonly IRepositorioEjercicio _repo;
    private readonly ValidadorEjercicio _validador;

    public ModificarEjercicioUseCase(IRepositorioEjercicio repo, ValidadorEjercicio validador)
    {
        _repo = repo;
        _validador = validador;
    }

    public void Ejecutar(int id, ActualizarEjercicioDto dto)
    {
        var ejercicio = _repo.ObtenerPorId(id);
        if (ejercicio == null)
            throw new Exception("Ejercicio no encontrado");

        ejercicio.Actualizar(
            dto.Nombre,
            dto.Descripcion,
            dto.Series,
            dto.Repeticiones
        );

        if (_validador.Validar(ejercicio, out var error))
            throw new Exception(error);

        _repo.ModificarEjercicio(ejercicio);
    }

}
