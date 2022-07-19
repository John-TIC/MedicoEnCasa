using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class FamiliarDesignado : Persona
    {
        [Required(ErrorMessage = "Ingrese un {0}")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Parentesco {get; set;}

        [Required(ErrorMessage = "Ingrese un E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un E-Mail valido")]
        public string Correo {get; set;}
    }
}