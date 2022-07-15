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
    public class MedicoModel : PageModel
    {
        [BindProperty]
        public Medico Medico {get; set;}

        private readonly IRepositorioMedico repositorioMedico;

        public MedicoModel(IRepositorioMedico repositorioMedico){
            this.repositorioMedico = repositorioMedico;
        }
        public IActionResult OnGet(int id)
        {
            Medico = repositorioMedico.GetMedico(id);

            if(Medico == null)
                return RedirectToPage("Error");

            ViewData["idMedico"] = id;

            return Page();
        }
    }
}
