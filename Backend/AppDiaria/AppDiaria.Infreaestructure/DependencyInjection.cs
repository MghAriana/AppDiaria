using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Infreaestructure.Repositorios;
using AppDiaria.Infreaestructure.DB;
using AppDiaria.Aplication.Interfaces.InterfacesSeccionEntrenamientos;
using AppDiaria.Infreaestructure.Repositorios.RepositoriosSeccionRutinas;
using AppDiaria.Aplication.UseCases.Entrenamiento;
using AppDiaria.Infreaestructure.Services;
using AppDiaria.Aplication.Interfaces.Login;

namespace AppDiaria.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // DbContext
        services.AddDbContext<AppDiariaContext>();
        // Services
        services.AddHttpContextAccessor();
        // Repositorios
        services.AddScoped<IRepositorioTarea, RepositorioTarea>();
        services.AddScoped<IRepositorioRecordatorio, RepositorioRecordatorio>();
        services.AddScoped<IRepositorioUsuario, RepositorioUsuario>(); // cuando exista
        services.AddScoped<IRepositorioEjercicio, RepositorioEjercicio>();
        services.AddScoped<IRepositorioEntrenamiento, RepositorioEntrenamientos>();
        services.AddScoped<IRepositorioRutina, RepositorioRutina>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}


