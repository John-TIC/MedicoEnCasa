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
        public FamiliarDesignado FamiliarDesignado { get; set; }

        [TempData]
        public int IdPaciente { get; set; }

        private readonly IRepositorioFamiliarDesignado repositorioFamiliar;
        private readonly IRepositorioPaciente repositorioPaciente;

        public NuevoFamiliarModel(IRepositorioFamiliarDesignado repositorioFamiliar, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int id)
        {
            Paciente paciente = repositorioPaciente.GetPaciente(id);

            if (paciente == null)
                return RedirectToPage("Error");

            ViewData["pacienteACuidar"] = paciente.Identificacion + " : " + paciente.Nombres + " " + paciente.Apellidos;
            IdPaciente = paciente.Id;

            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            FamiliarDesignado familiar = repositorioFamiliar.AddFamiliarDesignado(FamiliarDesignado);

            if (familiar == null)
                return RedirectToPage("Error");

            Paciente paciente = repositorioPaciente.GetPaciente(IdPaciente);

            if (paciente == null)
                return RedirectToPage("Error");

            paciente.FamiliarDesignado = familiar;
            repositorioPaciente.UpdatePaciente(paciente);

            return Page();
        }
    }
}
