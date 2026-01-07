using System;

namespace AppDiaria.Domain.Entidades;

public class Item
{
    public int Id { get; set; }
    public string Texto { get; set; }
    //agegar una imagen

    public Item(string text)
    {
        Texto= text;
    }

}
