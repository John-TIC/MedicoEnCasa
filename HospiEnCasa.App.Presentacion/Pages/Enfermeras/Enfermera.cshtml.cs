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
    public class EnfermeraModel : PageModel
    {
        [BindProperty]
        public Enfermera Enfermera {get; set;}

        private readonly IRepositorioEnfermera repositorioEnfermera;

        public EnfermeraModel(IRepositorioEnfermera repositorioEnfermera){
            this.repositorioEnfermera = repositorioEnfermera;
        }

        public IActionResult OnGet(int id)
        {
            Enfermera = repositorioEnfermera.GetEnfermera(id);

            if(Enfermera == null)
                return RedirectToPage("Error");

            ViewData["idEnfermera"] = id;

            return Page();
        }
    }
}