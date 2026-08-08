using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Interfaces.Login;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class AgregarRutinaUseCase(IRepositorioRutina _repo, ValidadorRutina _validador, ICurrentUserService _currentUser)
{
    public int Ejecutar(CrearRutinaDto dto) 
    {
        if (!_validador.Validar(dto, out var error))
            throw new Exception(error);

        var usuarioId = _currentUser.UsuarioId;

       if (!dto.EsPredeterminada && usuarioId == null)
            throw new UnauthorizedAccessException();

        var rutina = new Rutina(
            dto.Nombre,
            dto.Dia,
            dto.Descripcion ?? string.Empty,
            dto.EsPredeterminada,
            dto.EsPredeterminada ? null : usuarioId.Value
        );

        _repo.CrearRutina(rutina);
        return rutina.Id;
    }
}
