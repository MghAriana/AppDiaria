using System;
using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;

namespace AppDiaria.Aplication.Services;

public class RecordatorioService:IRecordatorioService
{
      private readonly IRepositorioRecordatorio _repositorioRecordatorio;
    public RecordatorioService(IRepositorioRecordatorio repositorioRecordatorio)
    {
        _repositorioRecordatorio = repositorioRecordatorio;
    }
        public List<RecordatorioDto> ListarRecordatorio()
        {
            return _repositorioRecordatorio.ListarRecordatorios()
                .Select(t => new RecordatorioDto
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Descripcion = t.Descripcion,
                    FechayHora = t.FechayHora,
            
                })
                .ToList();
        }

        public void CrearRecordatorio(CrearRecordatorioDto dto)
        {
            var record = new Recordatorio(
                dto.Nombre,
                dto.Descripcion,
                dto.FechayHora
            );

            _repositorioRecordatorio.CrearRecordatorio(record);
        }

        public void ActualizarRecordatorio(int id, ActualizarRecordatorioDto dto)
        {
            var recordatorio = _repositorioRecordatorio.ObtenerId(id);

            if (recordatorio == null)
                throw new Exception("Tarea no encontrada");

            recordatorio.Actualizar(
                dto.Nombre,
                dto.Descripcion,
                dto.FechayHora
            );

            _repositorioRecordatorio.ModificarRecordatorio(recordatorio);
        }

        public void EliminarRecordatorio(int id)
        {
            var tarea = _repositorioRecordatorio.ObtenerId(id);

            if (tarea == null)throw new Exception("No encontrado");

            _repositorioRecordatorio.EliminarRecordatorio(id);

        }

}
