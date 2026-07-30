using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

public interface IRepositorioEjercicio
{
    public void CrearEjercicio(Ejercicio ejercicio);
    public void EliminarEjercicio(int id);
    public void ModificarEjercicio(Ejercicio ejercicio);
    public List<Ejercicio> ListarEjercicios();
    public Ejercicio? ObtenerPorId(int id);

}
