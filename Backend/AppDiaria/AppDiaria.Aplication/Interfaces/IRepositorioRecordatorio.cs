using System;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Interfaces;

public interface IRepositorioRecordatorio
{
    public void CrearRecordatorio(Recordatorio recordatorio);
    public List<Recordatorio> ListarRecordatorios();
    public void EliminarRecordatorio(int id);
    public void ModificarRecordatorio(Recordatorio recordatorio);
}
