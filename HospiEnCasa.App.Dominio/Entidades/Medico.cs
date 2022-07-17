using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Medico : Persona
    {
        [Required(ErrorMessage = "Ingrese una Especialidad")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Especialidad debe tener entre 3 y 50 caracteres")]
        public string Especialidad {get; set;}

        [Required(ErrorMessage = "Ingrese un Codigo")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Codigo debe tener entre 3 y 20 caracteres")]
        public string Codigo {get; set;}

        [Required(ErrorMessage = "Ingrese un RegistroRethus")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "RegistroRethus debe tener entre 3 y 20 caracteres")]
        public string RegistroRethus {get; set;}
  
    }
}
