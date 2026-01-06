using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class AgregarUseCase(IRepositorioTarea repoT, ValidadorTarea validadorTarea)
{
    public void Ejecutar(Tarea tarea)
    {
        if (validadorTarea.Validar(tarea, out string MensajeError))
        {
            throw new Exception(MensajeError);
        }
        repoT.CrearTarea(tarea);
    }
}
