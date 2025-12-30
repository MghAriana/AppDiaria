using System;
using AppDiaria.Domain.Entidades;
namespace AppDiaria.Aplication.Validadores;

public class ValidadorTarea
{
    private readonly DateTime fecha;
    public bool ValidadorT(Tarea tarea, out string MensajeError)
    {
        MensajeError = "";
        if (string.IsNullOrWhiteSpace(tarea.getNombre()))
        {
            MensajeError += "el campo nombre no puede estar vacio";
        }
        if (!tarea.estaEnRango(fecha))
        {
            MensajeError += "la fecha es invalida";
        }

            return MensajeError == "";
    }
}
