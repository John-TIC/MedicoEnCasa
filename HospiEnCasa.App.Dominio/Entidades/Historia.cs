using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Historia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una {0}")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = "Ingrese una {0}")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Entorno { get; set; }
        public List<SugerenciaCuidado> Sugerencias { get; set; }
    }
}