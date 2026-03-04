using System;

using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.DTOS.Rutinas.RutinaEjercicio;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class ListarRutinaUseCase
{

    private readonly IRepositorioRutina _repositorio;

    public ListarRutinaUseCase(IRepositorioRutina repositorio)
    {
        _repositorio = repositorio;
    }

    public List<RutinaDto> Ejecutar()
    {
        var rutinas = _repositorio.ListarRutinas();

        return rutinas.Select(r => new RutinaDto
        {
            Id = r.Id,
            Nombre = r.Nombre,

            Dia = r.Dia.ToString(),
            Descripcion = r.Descripcion,
            Ejercicios = r.RutinaEjercicios.Select(re => new RutinaEjercicioDto
            {
                EjercicioId = re.EjercicioId,
                Nombre = re.Ejercicio.Nombre,
                Series = re.Series,
                Repeticiones = re.Repeticiones

            }).ToList()
        }).ToList();
    }
}

