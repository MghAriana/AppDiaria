using System;
using AppDiaria.Domain.Entidades;
namespace AppDiaria.Aplication.Validadores;

public class ValidadorTarea
{
    public bool Validar(Tarea tarea, out string mensajeError)
{
    mensajeError = "";

    if (string.IsNullOrWhiteSpace(tarea.Nombre))
        mensajeError += "El nombre no puede estar vacío.\n";

    if (tarea.Fecha > tarea.Fin)
        mensajeError += "La fecha de inicio no puede ser mayor a la de fin.\n";

    return mensajeError == "";
}
}
