using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;

namespace AppDiaria.Aplication.UseCases.RutinaEjercicio;

public class ModificarSeriesYRepeticionesUseCase
{
    private readonly IRepositorioRutina _repoRutina;
    private readonly ValidadorRutinaEjercicio _validador;

    public ModificarSeriesYRepeticionesUseCase(
        IRepositorioRutina repoRutina,
        ValidadorRutinaEjercicio validador)
    {
        _repoRutina = repoRutina;
        _validador = validador;
    }

    public void Ejecutar(ModificarSeriesRepsDto dto)
    {
        if (!_validador.Validar(dto.Series, dto.Repeticiones, out var error))
            throw new Exception(error);

        var rutina = _repoRutina.ObtnerPorId(dto.RutinaId)
            ?? throw new Exception("Rutina no existe");

        rutina.ModificarSeriesYRepeticiones(
            dto.EjercicioId,
            dto.Series,
            dto.Repeticiones
        );

        _repoRutina.GuardarCambios();
    }

}
