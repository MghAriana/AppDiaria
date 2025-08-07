using System;
using System.Data.Common;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Validadores;

public class ValidadorRecordatorio
{
    public bool Validador(Recordatorio recordatorio, out string MensajeError)
    {
        MensajeError = "";
        if (string.IsNullOrWhiteSpace(recordatorio.Nombre))
        {
            MensajeError += "el campo Nombre no puede estar vacio";
        }
        return MensajeError == "";
    }
}
