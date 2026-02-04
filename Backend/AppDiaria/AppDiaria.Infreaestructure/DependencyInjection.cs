using System;

using Microsoft.Extensions.DependencyInjection;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Infreaestructure.Repositorios;
using AppDiaria.Infreaestructure.DB;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Infreaestructure.Repositorios.RepositoriosSeccionRutinas;
using AppDiaria.Aplication.UseCases.Entrenamiento;

namespace AppDiaria.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // DbContext
        services.AddDbContext<AppDiariaContext>();

        // Repositorios
        services.AddScoped<IRepositorioTarea, RepositorioTarea>();
        services.AddScoped<IRepositorioRecordatorio, RepositorioRecordatorio>();
        services.AddScoped<IRepositorioUsuario, RepositorioUsuario>(); // cuando exista
        services.AddScoped<IRepositorioEjercicio, RepositorioEjercicio>();
        services.AddScoped<IRepositorioEntrenamiento, RepositorioEntrenamientos>();
        services.AddScoped<AgregarRutinaAEntrenamientoUseCase, AgregarRutinaAEntrenamientoUseCase>();

        services.AddScoped<IRepositorioRutina, RepositorioRutina>();

        return services;
    }
}


