using System;
using AppDiaria.Domain.Entidades;
using AppDiaria.Domain.Entidades.Rutinas;
using Microsoft.EntityFrameworkCore;
namespace AppDiaria.Infreaestructure.DB;

public class AppDiariaContext : DbContext
{
    
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Recordatorio> Recordatorios { get; set; }
    public DbSet<Rutina> Rutinas {get;set;}
    public DbSet<Entrenamientos> Entrenamientos {get;set;}
    public DbSet<Ejercicio> Ejercicios{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=AppDiaria.sqlite");
    }

    public AppDiariaContext()
    {
        this.Database.EnsureCreated();
        var connection = this.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA journal_mode=DELETE;";
        command.ExecuteNonQuery();
    } 
}
