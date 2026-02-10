using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Validadores.SeccionRutinas;

public class ValidadorRutina
{
    public bool Validar(CrearRutinaDto dto, out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(dto.Nombre))
            mensajeError += "El nombre de la rutina es obligatorio. ";

        if (!Enum.IsDefined(typeof(DayOfWeek), dto.Dia))
            mensajeError += "El día no es válido. ";


        if (dto.Ejercicios == null || !dto.Ejercicios.Any())
            mensajeError += "La rutina debe tener al menos un ejercicio. ";

        return mensajeError == "";
    }
    public bool ValidarActualizacion(ActualizarRutinaDto dto, out string mensajeError)
    {
        mensajeError = "";

        if (string.IsNullOrWhiteSpace(dto.Nombre))
            mensajeError += "El nombre de la rutina es obligatorio. ";

        if (!Enum.IsDefined(typeof(DayOfWeek), dto.Dia))
            mensajeError += "El día no es válido. ";

        return mensajeError == "";
    }
}
