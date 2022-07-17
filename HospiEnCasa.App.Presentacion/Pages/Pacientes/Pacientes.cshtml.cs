using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class PacientesModel : PageModel
    {
        private readonly IRepositorioPaciente repositorioPaciente;
        public IEnumerable<Paciente> Pacientes { get; set; }

        public PacientesModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet()
        {
            Pacientes = repositorioPaciente.GetAllPacientes();

            if(Pacientes == null)
                return RedirectToPage("Error");

            return Page();
        }
    }
}
