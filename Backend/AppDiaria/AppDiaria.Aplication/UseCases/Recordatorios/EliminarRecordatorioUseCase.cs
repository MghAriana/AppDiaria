using System;
using AppDiaria.Aplication.Interfaces;

namespace AppDiaria.Aplication.UseCases.Recordatorios;

public class EliminarRecordatorioUseCase(IRepositorioRecordatorio repositorioRecordatorio)
{
    public void Ejecutar(int id)
    {
        repositorioRecordatorio.EliminarRecordatorio(id);
    }
}
