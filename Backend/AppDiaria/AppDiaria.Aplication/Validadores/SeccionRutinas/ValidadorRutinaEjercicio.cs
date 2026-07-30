using System;

namespace AppDiaria.Aplication.Validadores.SeccionRutinas;

public class ValidadorRutinaEjercicio
{
    public bool Validar(int series, int repeticiones, out string error)
    {
        error = "";

        if (series <= 0)
            error += "Las series deben ser mayores a 0. ";

        if (repeticiones <= 0)
            error += "Las repeticiones deben ser mayores a 0. ";

        return error == "";
    }
}

