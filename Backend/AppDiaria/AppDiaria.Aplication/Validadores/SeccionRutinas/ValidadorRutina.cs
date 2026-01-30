using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Validadores.SeccionRutinas;

public class ValidadorRutina
{
    public bool Validar(Rutina rutina , out string mensajeError)
    {
        mensajeError="";
        if(string.IsNullOrWhiteSpace(rutina.Nombre))
            mensajeError+= "El campo nombre no puede estar vacio";
        if(rutina.Ejercicios is null)
            mensajeError+= "debe incluir al menos 1 ejercicio";
        return mensajeError =="";
    }

}
