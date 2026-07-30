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
   
    private readonly ValidadorRecordatorio _validador;

    public AgregarRecordatorioUseCase(
            IRepositorioRecordatorio repo,
            ValidadorRecordatorio validador
    )
    {
        _repo = repo;
        
        _validador = validador;
    }
    public void Ejecutar(CrearRecordatorioDto dto, int usuarioId)
    {


        var recordatorio = new Recordatorio(
            dto.Nombre,
            dto.Descripcion,
            dto.FechayHora,
            usuarioId
        );

        if (!_validador.Validador(recordatorio, out var error))
            throw new Exception(error);

        _repo.CrearRecordatorio(recordatorio);
    }
}
