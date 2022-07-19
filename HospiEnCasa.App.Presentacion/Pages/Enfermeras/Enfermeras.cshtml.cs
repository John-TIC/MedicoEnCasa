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
    public class EnfermerasModel : PageModel
    {
        private readonly IRepositorioEnfermera repositorioEnfermera;
        public IEnumerable<Enfermera> Enfermeras { get; set; }

        public EnfermerasModel(IRepositorioEnfermera repositorioEnfermera)
        {
            this.repositorioEnfermera = repositorioEnfermera;
        }
        public IActionResult OnGet()
        {
            Enfermeras = repositorioEnfermera.GetAllEnfermera();

            if (Enfermeras == null)
                return RedirectToPage("Error");
            return Page();

        }
    }
}
