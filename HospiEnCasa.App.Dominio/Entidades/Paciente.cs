using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Paciente : Persona
    {
        [Required(ErrorMessage = "Ingrese una {0}")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Direccion { get; set; }

        [Range(-90.0001, 90.0001, ErrorMessage = "{0} debe estar entre {1} y {2}")]
        public decimal? Latitud { get; set; }

        [Range(-180.0001, 180.0001, ErrorMessage = "{0} debe estar entre {1} y {2}")]
        public decimal? Longitud { get; set; }

        [Required(ErrorMessage = "Ingrese una {0}")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Ingrese una Fecha")]
        [DataType(DataType.Date, ErrorMessage = "Ingese una Fecha valida")]
        public DateTime FechaNacimiento { get; set; }

        public int? FamiliarDesignadoId { get; set; }
        public FamiliarDesignado FamiliarDesignado { get; set; }

        public int? EnfermeraId { get; set; }
        public Enfermera Enfermera { get; set; }

        public int? MedicoId { get; set; }
        public Medico Medico { get; set; }

        public int? HistoriaId { get; set; }
        public Historia Historia { get; set; }

        public List<SignoVital> SignosVitales { get; set; }
    }
}
