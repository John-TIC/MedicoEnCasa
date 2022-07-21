using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class SugerenciaCuidado
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una Fecha y Hora")]
        [DataType(DataType.DateTime, ErrorMessage = "Ingese una Fecha y Hora valida")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Ingrese una {0}")]
        public string Descripcion { get; set; }
    }
}