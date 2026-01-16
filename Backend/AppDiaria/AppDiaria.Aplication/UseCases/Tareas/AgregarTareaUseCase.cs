using System;
using AppDiaria.Aplication.DTOS.Tarea;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Tareas;

public class AgregarTareaUseCase
{
  
    private readonly IRepositorioTarea _repo;
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly ValidadorTarea _validador;

    public AgregarTareaUseCase(
        IRepositorioTarea repo,
        IRepositorioUsuario repoUsuario,
        ValidadorTarea validador)
    {
        _repo = repo;
        _repoUsuario = repoUsuario;
        _validador = validador;
    }

    public void Ejecutar(CrearTareaDto dto)
    {
        if (!_repoUsuario.Existe(dto.IdUsuario))
            throw new Exception("Usuario no existe");

        var tarea = new Tarea(
            dto.Nombre,
            dto.Descripcion,
            dto.Fecha,
            dto.Fin,
            dto.IdUsuario
        );

        if (!_validador.Validar(tarea, out var error))
            throw new Exception(error);

        _repo.CrearTarea(tarea);
    }
}

    /* simple para las pruebas si usuario
    public void Ejecutar(Tarea tarea)
    {
        if (validadorTarea.Validar(tarea, out string MensajeError))
        {
            throw new Exception(MensajeError);
        }
        repoT.CrearTarea(tarea);
    }*/

