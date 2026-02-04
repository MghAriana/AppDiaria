using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class ListarRutinaUseCase(IRepositorioRutina repositorioRutina)
{
    public List<Rutina> Ejecutar()
    {
        return repositorioRutina.ListarRutinas();
    }
}
