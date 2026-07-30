using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class ModificarRutinaUseCase
{
    private readonly IRepositorioRutina _repo;
    private readonly ValidadorRutina _validador;

    public ModificarRutinaUseCase(
        IRepositorioRutina repo,
        ValidadorRutina validador)
    {
        _repo = repo;
        _validador = validador;
    }

    public void Ejecutar(int id, ActualizarRutinaDto dto)
    {
        if (!_validador.ValidarActualizacion(dto, out var error))
            throw new Exception(error);

        var rutina = _repo.ObtnerPorId(id)
            ?? throw new Exception("Rutina no encontrada");

        rutina.Actualizar(
            dto.Nombre!,
            dto.Dia,
            dto.Descripcion!
        );

        _repo.GuardarCambios();
    }
}
