using System;
using AppDiaria.Aplication.Interfaces;
using AppDiaria.Domain.Entidades;


namespace AppDiaria.Aplication.Validadores;

public class ValidadorUsuario(IRepositorioUsuario repoUs)
{
    public bool Validador(Usuario usuario, out string MensajeError)
    {
        MensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
            MensajeError += "El capo nombre no puede estar Vacio";
        }
        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            MensajeError += "El campo Email no puede estar vacio.";
        }
        else
        {
            if (!repoUs.ExisteEmail(usuario.Email))
            {
                MensajeError = "Email no valido";
            }
        }
            
        
        return MensajeError == "";
    }
}
