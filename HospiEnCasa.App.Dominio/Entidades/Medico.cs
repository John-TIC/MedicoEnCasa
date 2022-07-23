using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Medico : Persona
    {
        [Required(ErrorMessage = "Ingrese una {0}")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Especialidad {get; set;}

        [Required(ErrorMessage = "Ingrese un {0}")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string RegistroRethus {get; set;}
    }
}
