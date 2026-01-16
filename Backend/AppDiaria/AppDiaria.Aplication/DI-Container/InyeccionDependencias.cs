using System;
using AppDiaria.Aplication.UseCases.Recordatorios;
using AppDiaria.Aplication.UseCases.Tareas;
using AppDiaria.Aplication.UseCases.Usuarios;
using AppDiaria.Aplication.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace AppDiaria.Aplication.DI_Container;

public static class InyeccionDependencias
{
       public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // USECASES
        //  Tarea
        services.AddScoped<AgregarTareaUseCase>();
        services.AddScoped<ListarTareaUseCase>();
        services.AddScoped<ModificarTareaUseCase>();
        services.AddScoped<EliminarTareaUseCase>();
        //Recordatorios
        services.AddScoped<AgregarRecordatorioUseCase>();
        services.AddScoped<ListarRecordatorioUseCase>();
        services.AddScoped<ModificarRecordatorioUseCase>();
        services.AddScoped<EliminarRecordatorioUseCase>();
        //usuario
        services.AddScoped<AgregarUsuarioUseCase>();
        services.AddScoped<ListarUsuarioUseCase>();
        services.AddScoped<ModificarUsuarioUseCase>();
        services.AddScoped<EliminarUsuarioUseCase>();
        services.AddScoped<ObtenerUsuarioUseCase>();
        
        // Validadores
        services.AddScoped<ValidadorTarea>();
        services.AddScoped<ValidadorUsuario>();
        services.AddScoped<ValidadorRecordatorio>();

        return services;
    }

}
