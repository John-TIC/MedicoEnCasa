using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class NuevoPacienteModel : PageModel
    {

        [BindProperty]
        public Paciente Paciente { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IRepositorioPaciente _repositorioPaciente;

        public NuevoPacienteModel(ILogger<IndexModel> logger, IRepositorioPaciente repositorioPaciente)
        {
            _logger = logger;
            _repositorioPaciente = repositorioPaciente;
        }

        public void OnGet()
        {
            _logger.LogInformation("Get method", DateTime.UtcNow.ToLongTimeString());
        }

        public IActionResult OnPost()
        {

            _logger.LogInformation("Get method", DateTime.UtcNow.ToLongTimeString());

            Paciente nuevoPaciente = _repositorioPaciente.AddPaciente(Paciente);

            if(nuevoPaciente == null){
                return RedirectToPage("Error");
            }

            return Page();
        }
    }
}
