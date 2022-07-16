using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class FamiliarDesignado : Persona
    {
        [Required(ErrorMessage = "Ingrese un Parentesco")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Parentesco debe tener entre 3 y 20 caracteres")]
        public string Parentesco {get; set;}

        [Required(ErrorMessage = "Ingrese un E-Mail valido")]
        [DataType(DataType.EmailAddress)]
        public string Correo {get; set;}
    }
}