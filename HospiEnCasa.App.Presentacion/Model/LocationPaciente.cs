using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospiEnCasa.App.Presentacion.Model
{
    public class LocationPaciente
    {
        public string FullName { get; set; }
        public string Diagnostico { get; set; }
        public decimal Latitud {get; set; }
        public decimal Longitud {get; set; }
        public int IdPaciente { get; set; }
    }
}