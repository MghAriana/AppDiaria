using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class ModificarRutinaUseCase
{
    private readonly IRepositorioRutina _repo;
    private readonly ValidadorRutina _validador;

    public ModificarRutinaUseCase(IRepositorioRutina repo, ValidadorRutina validador)
    {
        _repo = repo;
        _validador = validador;
    }

    public void Ejecutar(int id, ActualizarRutinaDto dto)
    {
        var rutina = _repo.ObtnerPorId(id);
        if (rutina == null)
            throw new Exception("Ejercicio no encontrado");

        rutina.Actualizar(
            dto.Nombre,
            dto.Dia,
            dto.Descripcion
        );

        if (_validador.Validar(rutina, out var error))
            throw new Exception(error);

        _repo.ModificarRutina(rutina);
    }

}
