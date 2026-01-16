using System;
using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.UseCases.Recordatorios;

public class ModificarRecordatorioUseCase
{
    private readonly IRepositorioRecordatorio _repo;
    private readonly ValidadorRecordatorio _validador;
    public ModificarRecordatorioUseCase(IRepositorioRecordatorio repo, ValidadorRecordatorio validador)
    {
        _repo= repo;
        _validador = validador;
    } 
    public void Ejecutar(int id, ActualizarRecordatorioDto dto)
    {
        var rec = _repo.ObtenerId(id);
        if(rec == null)
          throw new Exception("Recordatorio invalido ");  
        
        rec.Actualizar(
            dto.Nombre,
            dto.Descripcion,
            dto.FechayHora
            
        );
        if (!_validador.Validador(rec, out string MensajeError))
        {
            throw new Exception(MensajeError);
        }
        _repo.ModificarRecordatorio(rec);
    }
}
