using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Validadores.SeccionRutinas;

public class ValidadorEntrenamiento
{
    public bool Validar(Entrenamientos entrenamientos, out string mensajeError)
    {
        mensajeError="";
        if(string.IsNullOrWhiteSpace(entrenamientos.Nombre))
            mensajeError+= "El campo nombre no puede estar vacio \n";
        
        return mensajeError == "";
    }

}
