using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages.Medicos
{
    public class PacientesMedicoModel : PageModel
    {

        public Medico Medico { get; set; }

        public IEnumerable<Paciente> PacientesMedico { get; set; }

        private readonly IRepositorioPaciente repositorioPaciente;

        public PacientesMedicoModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int idMedico)
        {
            PacientesMedico = repositorioPaciente.GetPacientesPorMedico(idMedico);
            
            if(PacientesMedico == null || PacientesMedico.Count() == 0)
                PacientesMedico = null;

            return Page();
            
        }
    }
}