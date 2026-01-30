using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class EliminarRutinaUseCase(IRepositorioRutina repositorioRutina)
{
    public void Ejecutar(int id)
    {
        repositorioRutina.EliminarRutina(id);
    }
}
