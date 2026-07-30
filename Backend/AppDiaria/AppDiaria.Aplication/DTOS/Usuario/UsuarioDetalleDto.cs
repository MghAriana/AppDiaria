using System;
using System.ComponentModel.DataAnnotations;
using AppDiaria.Aplication.DTOS.Entrenamientos;
using AppDiaria.Aplication.DTOS.Recordatorio;
using AppDiaria.Aplication.DTOS.Tarea;

namespace AppDiaria.Aplication.DTOS.Usuario;

public class UsuarioDetalleDto
{
    [Key]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Email { get; set; }
    public DateTime FechaCreacion { get; set; }

    public List<TareaDto> Tareas { get; set; } = new();
    public List<RecordatorioDto> Recordatorios { get; set; } = new();
    public List<EntrenamientoDto> Entrenamientos { get; set; } = new();
}


