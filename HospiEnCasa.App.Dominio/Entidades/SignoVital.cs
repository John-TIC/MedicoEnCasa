using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospiEnCasa.App.Dominio
{
    public class SignoVital
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una Fecha")]
        [DataType(DataType.DateTime, ErrorMessage = "Ingese una Fecha valida")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Ingrese un {0}")]
        [DisplayFormat(DataFormatString = "{0,00}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        public TipoSigno Signo { get; set; }
    }
}