using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class NuevoPacienteModel : PageModel
    {

        [BindProperty]
        public Paciente Paciente { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public NuevoPacienteModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        public void OnGet()
        {
            _logger.LogInformation("About page visited at {DTS}",
            DateTime.UtcNow.ToLongTimeString());
        }

        public void OnPost()
        {
            _logger.LogInformation("About page visited at {DT}",
                        DateTime.UtcNow.ToLongTimeString());
        }
    }
}
