
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una Identificacion")]
        [StringLength(20, MinimumLength =6, ErrorMessage = "Identificacion debe tener entre 6 y 20 caracteres")]
        public string Identificacion {get; set;}

        [Required(ErrorMessage = "Ingrese un Nombre")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Nombres debe tener entre 2 y 20 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Ingrese un Apellido")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Apellidos debe tener entre 2 y 20 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Ingrese un Numero de Telefono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Ingrese un Numero Telefonico valido")]
        public string NumeroTelefono { get; set; }

        public Genero Genero { get; set; }
    }
}