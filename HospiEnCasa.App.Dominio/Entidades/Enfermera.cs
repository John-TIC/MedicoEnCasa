using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Enfermera : Persona{
        
        [Required(ErrorMessage = "Ingrese una Tarjeta Profesional")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Tarjeta Profesional debe tener entre {2} y {1} caracteres")]
        public string TarjetaProfesional {get; set;}
        
        public int HorasLaborales {get; set;}
    }
}