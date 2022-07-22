using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class SignoVital
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una Fecha")]
        [DataType(DataType.Date, ErrorMessage = "Ingese una Fecha valida")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Ingrese un {0}")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public float Valor { get; set; }
        public TipoSigno Signo { get; set; }
    }
}