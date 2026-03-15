    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace AppDiaria.Domain.Entidades.Rutinas;

    public class Entrenamientos
    {
        [Key]
        public int Id{get; set;}
        public string? Nombre{get;set;}
        public DateOnly Fecha{get;private set;}
        public ICollection<EntrenamientoRutina> EntrenamientoRutinas { get; private set; } = new List<EntrenamientoRutina>();//mas adelante ver si es ICollection
        public int UsuarioId{get;private set;}
        public Usuario? Usuario{get;set;}

        protected Entrenamientos(){}//ef
        public Entrenamientos(string nombre, DateOnly fecha, int usuarioId)
        {
            Nombre= nombre;
            Fecha=fecha;
            this.UsuarioId=usuarioId;
        }
        
        public void AgregarRutina(Rutina rutina)
        {
            if (EntrenamientoRutinas.Any(er => er.RutinaId == rutina.Id))
                throw new Exception("La rutina ya está asociada");

            EntrenamientoRutinas.Add(
                new EntrenamientoRutina(this, rutina)
            );
        }

        public void Actualizar(string nombre, DateOnly fecha)
        {
            Nombre= nombre;
            Fecha=fecha;
        }

    }
