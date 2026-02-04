using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Ejercicios;

public class ListarEjercicioUseCase(IRepositorioEjercicio repositorioEjercicio)
{
    public List<Ejercicio> Ejecutar()
    {
        return repositorioEjercicio.ListarEjercicios();
    }
}
