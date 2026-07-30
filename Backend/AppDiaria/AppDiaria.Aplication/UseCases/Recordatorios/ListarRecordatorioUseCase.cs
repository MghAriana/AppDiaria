using System;
using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Recordatorios;

public class ListarRecordatorioUseCase(IRepositorioRecordatorio repoRec)
{
   public List<Recordatorio> Ejecutar(int usuarioId)
    {
        return repoRec.ListarRecordatorios(usuarioId);
    }
}
