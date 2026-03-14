using System;
using AppDiaria.Aplication.Interfaces;

namespace AppDiaria.Aplication.UseCases.Recordatorios;

public class EliminarRecordatorioUseCase(IRepositorioRecordatorio repositorioRecordatorio)
{
    public void Ejecutar(int id, int usuarioId)
    {
        var recordatorio = repositorioRecordatorio.ObtenerId(id);

        if (recordatorio == null)
            throw new Exception("Recordatorio no encontrado");

         if (recordatorio.UsuarioId != usuarioId)
            throw new Exception("No autorizado");
            
        repositorioRecordatorio.EliminarRecordatorio(id);
    }
}
