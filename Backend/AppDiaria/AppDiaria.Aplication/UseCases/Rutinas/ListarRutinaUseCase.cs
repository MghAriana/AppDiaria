using System;

using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.DTOS.Rutinas.RutinaEjercicio;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class ListarRutinaUseCase(IRepositorioRutina _repo)
{

    public List<RutinaDto> Ejecutar()
    {
        var rutinas = _repo.ObtenerPredeterminadas();

        return rutinas.Select(r => new RutinaDto
                        {
                            Id = r.Id,
                            Nombre = r.Nombre,
                            Dia = r.Dia.ToString(),
                            Descripcion = r.Descripcion,
                            EsPredeterminada = r.EsPredeterminada, // ✅ FIX
                            Ejercicios = r.RutinaEjercicios.Select(re => new RutinaEjercicioDto
                            {
                                EjercicioId = re.EjercicioId,
                                Nombre = re.Ejercicio.Nombre,
                                Series = re.Series,
                                Repeticiones = re.Repeticiones,
                                CaloriasPorRepeticion = re.CaloriasPorRepeticion
                            }).ToList()
                        }).ToList();
                        }
}
    


