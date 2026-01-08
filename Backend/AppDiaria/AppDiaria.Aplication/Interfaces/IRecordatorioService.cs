using System;
using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Interfaces;

public interface IRecordatorioService
{
        List<RecordatorioDto> ListarRecordatorio();
        void CrearRecordatorio(CrearRecordatorioDto dto);
        void ActualizarRecordatorio(int id,ActualizarRecordatorioDto dto);
        void EliminarRecordatorio(int id);
        
}
