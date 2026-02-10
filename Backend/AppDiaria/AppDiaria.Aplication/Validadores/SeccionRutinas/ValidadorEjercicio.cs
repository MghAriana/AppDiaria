using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Validadores.SeccionRutinas;

public class ValidadorEjercicio
{
    public bool Validar(Ejercicio ejercicio, out string error)
{
    error = "";

    if (string.IsNullOrWhiteSpace(ejercicio.Nombre))
        error = "El nombre es obligatorio";

    return error == "";
}


}
