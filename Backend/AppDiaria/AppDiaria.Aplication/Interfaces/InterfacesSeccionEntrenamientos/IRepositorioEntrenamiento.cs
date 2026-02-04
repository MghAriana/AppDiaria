using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

public interface IRepositorioEntrenamiento
{
    public void CrearEntrenamiento(Entrenamientos entrenamientos);
    public void EliminarEntrenamiento(int id);
    public List<Entrenamientos> ListarEntrenamientos();
    public void ModificarEntrenamiento(Entrenamientos entrenamientos);
    public Entrenamientos ObtenerPorId(int id);
    public void GuardarCambios();


}
