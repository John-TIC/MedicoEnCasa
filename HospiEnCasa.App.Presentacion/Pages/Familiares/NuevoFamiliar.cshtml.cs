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
    public class NuevoFamiliarModel : PageModel
    {
        [BindProperty]
        public FamiliarDesignado FamiliarDesignado {get; set;}
        [BindProperty]
        public Paciente Paciente {get; set;}

        private readonly IRepositorioFamiliarDesignado repositorioFamiliar;
        private readonly IRepositorioPaciente repositorioPaciente;

        public NuevoFamiliarModel(IRepositorioFamiliarDesignado repositorioFamiliar, IRepositorioPaciente repositorioPaciente){
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int id)
        {
            Paciente = repositorioPaciente.GetPaciente(id);

            if(Paciente == null)
                return RedirectToPage("Error");

            ViewData["pacienteACuidar"] = Paciente.Identificacion + " : " + Paciente.Nombres + " " + Paciente.Apellidos;

            return Page();

        }

        public IActionResult OnPost(){
            FamiliarDesignado familiar = repositorioFamiliar.AddFamiliarDesignado(FamiliarDesignado);

            if(familiar == null)
                return RedirectToPage("Error");

            Paciente.FamiliarDesignado = familiar;

            repositorioPaciente.UpdatePaciente(Paciente);

            return Page();
        }
    }
}
