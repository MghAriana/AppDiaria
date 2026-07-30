using System;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.DTOS.Tarea;
using AppDiaria.Aplication.DTOS.Usuario;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Usuarios;

public class ObtenerUsuarioUseCase
{
    private readonly IRepositorioUsuario _repo;

    public ObtenerUsuarioUseCase(IRepositorioUsuario repo)
    {
        _repo = repo;
    }

    public UsuarioDetalleDto? Ejecutar(int idUsuario)
    {
        var usuario = _repo.ObtenerUsuario(idUsuario);

        if (usuario == null)
            return null;

        return new UsuarioDetalleDto
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            FechaCreacion = usuario.FechaCreacion,

            Tareas = usuario.Tareas.Select(t => new TareaDto
            {
                Id = t.Id,
                Descripcion = t.Descripcion
            }).ToList(),

            Recordatorios = usuario.Recordatorios.Select(r => new RecordatorioDto
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList(),

            Entrenamientos = usuario.Entrenamientos.Select(e => new EntrenamientoDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Fecha = e.Fecha
            }).ToList()
        };
    }
}
