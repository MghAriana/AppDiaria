using System;
using AppDiaria.Domain.Entidades;
using AppDiaria.Domain.Entidades.Rutinas;
using Microsoft.EntityFrameworkCore;
namespace AppDiaria.Infreaestructure.DB;

public class AppDiariaContext : DbContext
{
    
    public AppDiariaContext(DbContextOptions<AppDiariaContext> options)
        : base(options)
    {
    }
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Recordatorio> Recordatorios { get; set; }
    public DbSet<Rutina> Rutinas {get;set;}
    public DbSet<Entrenamientos> Entrenamientos {get;set;}
    public DbSet<EntrenamientoRutina> EntrenamientoRutinas{get;set;}
    public DbSet<Ejercicio> Ejercicios{get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<EntrenamientoRutina>()
        .HasKey(er => new { er.EntrenamientoId, er.RutinaId });

    modelBuilder.Entity<EntrenamientoRutina>()
        .HasOne(er => er.Entrenamiento)
        .WithMany(e => e.EntrenamientoRutinas)
        .HasForeignKey(er => er.EntrenamientoId);

    modelBuilder.Entity<EntrenamientoRutina>()
        .HasOne(er => er.Rutina)
        .WithMany(r => r.EntrenamientoRutinas)
        .HasForeignKey(er => er.RutinaId);
}


    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
    } */
}
