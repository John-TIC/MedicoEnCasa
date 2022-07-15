using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio
{
    public class Paciente : Persona
    {
        [Required, StringLength(20)]
        public string Direccion { get; set; }
        [Required, StringLength(15)]
        public float Latitud { get; set; }
        [Required, StringLength(15)]
        public float Longitud { get; set; }
        [Required, StringLength(20)]
        public string Ciudad { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }
        public FamiliarDesignado FamiliarDesignado { get; set; }
        public Enfermera Enfermera { get; set; }
        public Medico Medico { get; set; }
        public Historia Historia { get; set; }
        public List<SignoVital> SignosVitales { get; set; }
    }
}
