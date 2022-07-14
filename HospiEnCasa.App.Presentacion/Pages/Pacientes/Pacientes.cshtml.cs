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
        [BindProperty]
        public IEnumerable<Paciente> Paciente {get; set;}
        
        public PacientesModel(IRepositorioPaciente repositorioPaciente)
        {
                this.repositorioPaciente = repositorioPaciente;
        }
        public void OnGet()
        {
            Paciente = repositorioPaciente.GetAllPacientes();
        }
    }
}
