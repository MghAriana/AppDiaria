using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Recordatorios;

public class AgregarUseCase(IRepositorioRecordatorio repoRec , ValidadorRecordatorio validador)
{
    public void Ejecutar(Recordatorio recordatorio)
    {
        if (!validador.Validador(recordatorio, out string MensajeError))
        {
            throw new Exception(MensajeError);
        }
        repoRec.CrearRecordatorio(recordatorio);
    }
}
