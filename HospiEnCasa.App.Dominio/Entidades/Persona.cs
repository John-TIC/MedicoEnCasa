
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        [Required, StringLength(10)]
        public string Identificacion {get; set;}
        [Required, StringLength(30)]
        public string Nombres { get; set; }
        [Required, StringLength(30)]
        public string Apellidos { get; set; }
        [Required, StringLength(10)]
        public string NumeroTelefono { get; set; }
        [Required]
        public Genero Genero { get; set; }
    }
}