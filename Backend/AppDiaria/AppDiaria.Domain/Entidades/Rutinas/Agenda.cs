using System;

namespace AppDiaria.Domain.Entidades.Rutinas;

public class Agenda
{
    public int Id{get; set;}
    public int MesyAño;
    public Rutina Rutinas{get;set;}

}
