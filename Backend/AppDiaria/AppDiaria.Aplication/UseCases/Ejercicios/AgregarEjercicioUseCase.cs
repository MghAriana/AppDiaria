using System;
using AppDiaria.Aplication.DTOS.Ejercicios;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Ejercicios;

public class AgregarEjercicioUseCase
{
  
    private readonly IRepositorioEjercicio _repo;
    private readonly ValidadorEjercicio _validador;

    public AgregarEjercicioUseCase(
        IRepositorioEjercicio repo,
        IRepositorioUsuario repoUsuario,
        ValidadorEjercicio validador)
    {
        _repo = repo;
        
        _validador = validador;
    }

    public void Ejecutar(CrearEjercicioDto dto)
    {
        var ejercicio = new Ejercicio(
            dto.Nombre,
            dto.Descripcion,
            dto.Series,
            dto.Repeticiones
        );

        if (!_validador.Validar(ejercicio, out var error))
            throw new Exception(error);

        _repo.CrearEjercicio(ejercicio);
    }
}

