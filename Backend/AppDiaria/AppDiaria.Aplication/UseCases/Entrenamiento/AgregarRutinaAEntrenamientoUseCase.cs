using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

namespace AppDiaria.Aplication.UseCases.Entrenamiento;

public class AgregarRutinaAEntrenamientoUseCase
{
    private readonly IRepositorioEntrenamiento _repoEntrenamiento;
    private readonly IRepositorioRutina _repoRutina;

    public AgregarRutinaAEntrenamientoUseCase(
        IRepositorioEntrenamiento repoEntrenamiento,
        IRepositorioRutina repoRutina)
    {
        _repoEntrenamiento = repoEntrenamiento;
        _repoRutina = repoRutina;
    }

   public void Ejecutar(int entrenamientoId, int rutinaId)
{
    var entrenamiento = _repoEntrenamiento.ObtenerPorId(entrenamientoId)
        ?? throw new Exception("Entrenamiento no existe");

    var rutina = _repoRutina.ObtnerPorId(rutinaId)
        ?? throw new Exception("Rutina no existe");

    entrenamiento.AgregarRutina(rutina);

    _repoEntrenamiento.GuardarCambios();
}
}

