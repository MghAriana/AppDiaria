using System;

using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

namespace AppDiaria.Aplication.UseCases.RutinaEjercicio;

public class QuitarEjercicioDeRutinaUseCase
{
    private readonly IRepositorioRutina _repoRutina;

    public QuitarEjercicioDeRutinaUseCase(IRepositorioRutina repoRutina)
    {
        _repoRutina = repoRutina;
    }

    public void Ejecutar(QuitarEjercicioDeRutinaDto dto)
    {
        var rutina = _repoRutina.ObtnerPorId(dto.RutinaId)
            ?? throw new Exception("Rutina no existe");

        var relacion = rutina.RutinaEjercicios
            .FirstOrDefault(re => re.EjercicioId == dto.EjercicioId);

        if (relacion == null)
            throw new Exception("El ejercicio no pertenece a la rutina");

        rutina.RutinaEjercicios.Remove(relacion);

        _repoRutina.GuardarCambios();
    }
}

