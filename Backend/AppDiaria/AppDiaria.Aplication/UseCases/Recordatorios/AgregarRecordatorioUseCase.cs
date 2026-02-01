using System;
using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.DTOS.Usuario;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Recordatorios;

public class AgregarRecordatorioUseCase 
{
    private readonly IRepositorioRecordatorio _repo;
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly ValidadorRecordatorio _validador;

    public AgregarRecordatorioUseCase(
            IRepositorioRecordatorio repo,
            IRepositorioUsuario repoUs,
            ValidadorRecordatorio validador
    )
    {
        _repo = repo;
        _repoUsuario= repoUs;
        _validador = validador;
    }
    public void Ejecutar(CrearRecordatorioDto dto)
    {
        if (!_repoUsuario.Existe(dto.UsuarioId))
            throw new Exception("Usuario no existe");

        var recordatorio = new Recordatorio(
            dto.Nombre,
            dto.Descripcion,
            dto.FechayHora,
            dto.UsuarioId
            
        );

        if (!_validador.Validador(recordatorio, out var error))
            throw new Exception(error);

        _repo.CrearRecordatorio(recordatorio);
    }
}
