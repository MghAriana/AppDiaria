using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class AgregarRutinaUseCase
{
    private readonly IRepositorioRutina _repo;
    private readonly ValidadorRutina _validador;

    public AgregarRutinaUseCase(
        IRepositorioRutina repo,
        ValidadorRutina validador)
    {
        _repo = repo;
        _validador = validador;
    }

    public int Ejecutar(CrearRutinaDto dto)
    {
        if (!_validador.Validar(dto, out var error))
            throw new Exception(error);

        var rutina = new Rutina(
            dto.Nombre,
            dto.Dia,
            dto.Descripcion,
            dto.EsPredeterminada
        );

        _repo.CrearRutina(rutina);
        return rutina.Id;
    }
}
