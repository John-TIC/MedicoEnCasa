using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class PacienteModel : PageModel
    {
        [BindProperty]
        public Paciente Paciente {get; set;}

        private readonly IRepositorioPaciente repositorioPaciente;

        public PacienteModel(IRepositorioPaciente repositorioPaciente){
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int id)
        {
            Paciente = repositorioPaciente.GetPaciente(id);

            if(Paciente == null)
                return RedirectToPage("Error");

            ViewData["idPaciente"] = id;

            return Page();
        }
    }
}
