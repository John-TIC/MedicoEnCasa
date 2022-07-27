using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages.Medicos
{
    [Authorize]
    public class PacientesMedicoModel : PageModel
    {
        public Medico Medico { get; set; }
        public string FullNameMedico {get; set;}
        public IEnumerable<Paciente> PacientesMedico { get; set; }

        private readonly IRepositorioMedico repositorioMedico;

        public PacientesMedicoModel(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }

        public IActionResult OnGet(int idMedico)
        {
            Medico = repositorioMedico.GetMedico(idMedico);
            PacientesMedico = repositorioMedico.GetPacientesPorMedico(idMedico);
            
            if(PacientesMedico == null || PacientesMedico.Count() == 0)
                PacientesMedico = null;

            FullNameMedico = Medico.Nombres + " " + Medico.Apellidos;
            
            return Page();
            
        }
    }
}