using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Paciente : Persona
    {
        [Required(ErrorMessage = "Ingrese una Direccion")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Direccion debe tener entre 5 y 50 caracteres")]
        public string Direccion { get; set; }

        [Range(-90.0000, 90.0000)]
        public decimal? Latitud { get; set; }

        [Range(-180.0000, 180.0000)]
        public decimal? Longitud { get; set; }
        
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Ingrese una Direccion")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public int? FamiliarDesignadoId { get; set;}
        public FamiliarDesignado FamiliarDesignado { get; set; }

        public int? EnfermeraId { get; set;}
        public Enfermera Enfermera { get; set; }

        public int? MedicoId { get; set;}
        public Medico Medico { get; set; }

        public int? HistoriaId { get; set;}
        public Historia Historia { get; set; }

        public List<SignoVital> SignosVitales { get; set; }
    }
}
