using System;
using AppDiaria.Aplication.DTOS.Ejercicios;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class ListarRutinaUseCase(IRepositorioRutina repositorioRutina)
{
    public List<RutinaDto> Ejecutar()
    {
        var rutinas = repositorioRutina.ListarRutinas();

        return rutinas.Select(r => new RutinaDto
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Descripcion = r.Descripcion,
            Dia = r.Dia.ToString(),
            Ejercicios = r.RutinaEjercicios.Select(re => new CrearEjercicioDto
            {
                Nombre = re.Ejercicio.Nombre
            }).ToList()
        }).ToList();
    }
}
