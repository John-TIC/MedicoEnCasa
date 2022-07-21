using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class NuevoPacienteModel : PageModel
    {

        [BindProperty]
        public Paciente Paciente { get; set; }

        [BindProperty]
        public Historia Historia {get; set;}

        [BindProperty]
        public SugerenciaCuidado SugerenciaCuidado {get; set;}

        public bool IsCreatePaciente { get; set; }
        public ModalInfo ModalInfo {get; set; }

        private readonly IRepositorioPaciente repositorioPaciente;

        public NuevoPacienteModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            IsCreatePaciente = false;

            if (!ModelState.IsValid)
                return Page();
            
            Paciente.Historia = Historia;
            Historia.Sugerencias = new List<SugerenciaCuidado>{
                SugerenciaCuidado
            };
                
            Paciente nuevoPaciente = repositorioPaciente.AddPaciente(Paciente);

            if(nuevoPaciente == null)
                return RedirectToPage("Error");

            ModalInfo = new ModalInfo{
                TitleModal = "Nuevo Paciente",
                MsgModal = "Paciente " + nuevoPaciente.Nombres + " " + nuevoPaciente.Apellidos + " creado correctamente",
                PageRedirect = "/Pacientes/Pacientes"
            };

            IsCreatePaciente = true;

            return Page();
        }
    }
}
