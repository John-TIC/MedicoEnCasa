using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class FamiliarModel : PageModel
    {

        [BindProperty]
        public FamiliarDesignado FamiliarDesignado { get; set; }

        private readonly IRepositorioFamiliarDesignado repositorioFamiliar;
        private readonly IRepositorioPaciente repositorioPaciente;

        public FamiliarModel(IRepositorioFamiliarDesignado repositorioFamiliar, IRepositorioPaciente repositorioPaciente)
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

            FamiliarDesignado = repositorioFamiliar.GetFamiliarDesignado((int)paciente.FamiliarDesignadoId);

            if (FamiliarDesignado == null)
                return RedirectToPage("Error");

            return Page();
        }
    }
}
