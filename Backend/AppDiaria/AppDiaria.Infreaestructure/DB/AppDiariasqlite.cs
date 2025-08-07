using System;

namespace AppDiaria.Infreaestructure.DB;

public class AppDiariasqlite
{
    public static void Iniciar()
    {
        using var context = new AppDiariaContext();
         if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creo la base de datos");

            context.SaveChanges();
        }
    }
}
