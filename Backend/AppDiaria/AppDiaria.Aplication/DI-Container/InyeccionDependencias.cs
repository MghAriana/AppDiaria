using System;
using AppDiaria.Aplication.UseCases.Ejercicios;
using AppDiaria.Aplication.UseCases.Entrenamiento;
using AppDiaria.Aplication.UseCases.Recordatorios;
using AppDiaria.Aplication.UseCases.Rutinas;
using AppDiaria.Aplication.UseCases.Tareas;
using AppDiaria.Aplication.UseCases.Usuarios;
using AppDiaria.Aplication.Validadores;
using AppDiaria.Aplication.Validadores.SeccionRutinas;
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
        /////////////////////////seccion Rutinas////////////
        /// Rutina
        services.AddScoped<AgregarRutinaUseCase>();
        services.AddScoped<ListarRutinaUseCase>();
        services.AddScoped<ModificarRutinaUseCase>();
        services.AddScoped<EliminarRutinaUseCase>();
        /// Ejercicio
        services.AddScoped<AgregarEjercicioUseCase>();
        services.AddScoped<ListarEjercicioUseCase>();
        services.AddScoped<EliminarEjercicioUseCase>();
        services.AddScoped<ModificarEjercicioUseCase>();
        /// Entrenamiento
        services.AddScoped<AgregarEntrenamientoUseCase>();
        services.AddScoped<ListarEntrenamientoUseCase>();
        services.AddScoped<ModificarEntrenamientoUseCase>();
        services.AddScoped<EliminarEntrenamientoUseCase>();
        services.AddScoped<ListarEntrenamientosPorFechaUseCase>();
        /// validadores
        services.AddScoped<ValidadorEjercicio>();
        services.AddScoped<ValidadorRutina>();
        services.AddScoped<ValidadorEntrenamiento>();

        return services;
    }

}
