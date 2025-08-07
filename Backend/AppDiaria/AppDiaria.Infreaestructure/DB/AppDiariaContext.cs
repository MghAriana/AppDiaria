using System;
using AppDiaria.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
namespace AppDiaria.Infreaestructure.DB;

public class AppDiariaContext : DbContext
{
    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Recordatorio> Recordatorios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
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
