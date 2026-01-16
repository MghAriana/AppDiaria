using System;

using Microsoft.Extensions.DependencyInjection;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Infreaestructure.Repositorios;
using AppDiaria.Infreaestructure.DB;

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

        return services;
    }
}


