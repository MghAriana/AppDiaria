using System;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.Validadores.SeccionRutinas;

public class ValidadorEjercicio
{
    public bool Validar(Ejercicio ejercicio, out string mensajeError)
    {
        mensajeError="";
        
    if (string.IsNullOrWhiteSpace(ejercicio.Nombre))
        mensajeError += "El nombre no puede estar vacío.\n";
    if( ejercicio.Series == 0)
    {
        mensajeError+= "debe hacer minimo 1 serie";
    }
    if(ejercicio.Repeticiones<=2) mensajeError+= "haga como minimo 5-8 repeticiones";
        return mensajeError == "";
        
    }

}
