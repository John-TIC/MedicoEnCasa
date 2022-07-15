using System;
using System.Collections.Generic;

namespace HospiEnCasa.App.Dominio
{
    public class Paciente : Persona
    {
        public string Direccion { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string Ciudad { get; set; }
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
