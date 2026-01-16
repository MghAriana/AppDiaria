using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Recordatorios;

public class ListarRecordatorioUseCase(IRepositorioRecordatorio repoRec)
{
    public List<Recordatorio> Ejecutar()
    {
        return repoRec.ListarRecordatorios();
    }
}
