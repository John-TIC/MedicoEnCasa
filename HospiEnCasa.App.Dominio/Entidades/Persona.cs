
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una {0}")]
        [StringLength(10, MinimumLength =6, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Identificacion {get; set;}

        [Required(ErrorMessage = "Ingrese un {0}")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Ingrese un {0}")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Apellidos debe tener entre {2} y {1} caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Ingrese un Numero de Telefono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Ingrese un Numero Telefonico valido")]
        [StringLength(13, MinimumLength =6, ErrorMessage = "Teléfono debe tener entre {2} y {1} caracteres")]
        public string NumeroTelefono { get; set; }

        public Genero Genero { get; set; }
    }
}