using System;
using AppDiaria.Aplication.DTOS.Rutinas;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
using AppDiaria.Domain.Entidades.Rutinas;

namespace AppDiaria.Aplication.UseCases.Rutinas;

public class AgregarRutinaUseCase
{
     private readonly IRepositorioRutina _repo;
    private readonly ValidadorRutina _validador;

    public AgregarRutinaUseCase(
        IRepositorioRutina repo,
        ValidadorRutina validador)
    {
        _repo = repo;
        
        _validador = validador;
    }

    public void Ejecutar(CrearRutinaDto dto)
    {
    
        var rutina = new Rutina(
            dto.Nombre,
            dto.Dia,
            dto.Descripcion
            
        );

        if (!_validador.Validar(rutina, out var error))
            throw new Exception(error);

        _repo.CrearRutina(rutina);
    }

}
