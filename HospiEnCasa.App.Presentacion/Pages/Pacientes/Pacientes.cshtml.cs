using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
    public class PacientesModel : PageModel
    {
        private readonly IRepositorioPaciente repositorioPaciente;
        public IEnumerable<Paciente> Pacientes { get; set; }

        public PacientesModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet(string filtroB, string criterio)
        {
            //Pacientes = repositorioPaciente.GetAllPacientes();
            Pacientes = repositorioPaciente.GetPacientesXFiltro(filtroB, criterio);

            if(Pacientes == null || Pacientes.Count() == 0)
                Pacientes = null;

            return Page();
        }
    }
}
