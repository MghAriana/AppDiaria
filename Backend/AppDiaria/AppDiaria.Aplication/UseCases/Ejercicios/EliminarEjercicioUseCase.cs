using System;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

namespace AppDiaria.Aplication.UseCases.Ejercicios;

public class EliminarEjercicioUseCase(IRepositorioEjercicio repositorio)
{
    public void Ejecutar(int id)
    {
        repositorio.EliminarEjercicio(id);
    }

}
