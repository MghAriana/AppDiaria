using System;
using AppDiaria.Domain.Entidades;
namespace AppDiaria.Aplication.Validadores;

public class ValidadorTarea
{
    public bool ValidadorT(Tarea tarea, out string MensajeError)
    {
        MensajeError = "";
        if (string.IsNullOrWhiteSpace(tarea.Nombre))
        {
            MensajeError += "el campo nombre no puede estar vacio";
        }

        return MensajeError == "";
    }
}
