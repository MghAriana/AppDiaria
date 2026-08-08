using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;

public interface IRepositorioRutina
{
    public void CrearRutina(Rutina rutina);
    public List<Rutina> ObtenerDisponibles(int? usuarioId);
    public List<Rutina> ObtenerPredeterminadas();
    public void EliminarRutina(int id);
    public void ModificarRutina(Rutina rutina);
    public Rutina ObtnerPorId(int id);
    void GuardarCambios();
}
