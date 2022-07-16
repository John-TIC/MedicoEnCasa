using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class NuevoMedicoModel : PageModel
    {
        [BindProperty]
        public Medico Medico { get; set; }

        private readonly IRepositorioMedico repositorioMedico;

        public NuevoMedicoModel(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();
                
            Medico nuevoMedico = repositorioMedico.AddMedico(Medico);

            if(nuevoMedico == null){
                return RedirectToPage("Error");
            }

            return Page();
        }
    }
}
