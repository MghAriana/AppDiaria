using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;

namespace AppDiaria.Aplication.UseCases.RutinaEjercicio;

public class AgregarEjercicioARutinaUseCase
{
    private readonly IRepositorioRutina _repoRutina;
    private readonly ValidadorRutinaEjercicio _validador;
    private readonly IRepositorioEjercicio _repoEjercicio;

    public AgregarEjercicioARutinaUseCase(
        IRepositorioRutina repoRutina,
        ValidadorRutinaEjercicio validador,
        IRepositorioEjercicio repoEjercicio)
    {
        _repoRutina = repoRutina;
        _validador = validador;
        _repoEjercicio = repoEjercicio;
    }

    public void Ejecutar(AgregarEjercicioARutinaDto dto)
    {

        var rutina = _repoRutina.ObtnerPorId(dto.RutinaId)
            ?? throw new Exception("Rutina no existe");

        foreach (var e in dto.Ejercicios)
        {
            if (!_validador.Validar(e.Series, e.Repeticiones, out var error))
        throw new Exception(error);
            var ejercicio = _repoEjercicio.ObtenerPorId(e.EjercicioId)
                ?? throw new Exception("Ejercicio no existe");

            rutina.AgregarEjercicio(
                ejercicio,
                e.Series,
                e.Repeticiones
            );
        }

        _repoRutina.GuardarCambios();
    }

}
