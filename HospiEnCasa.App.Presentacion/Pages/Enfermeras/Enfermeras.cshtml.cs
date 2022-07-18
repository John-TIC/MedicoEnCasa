using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class EnfermerasModel : PageModel
    {
<<<<<<< HEAD
=======

>>>>>>> 6f25dcb528736312d41f49d14afc600fc7970168
        private readonly IRepositorioEnfermera repositorioEnfermera;
        public IEnumerable<Enfermera> Enfermeras { get; set; }

        public EnfermerasModel(IRepositorioEnfermera repositorioEnfermera)
<<<<<<< HEAD
        {
            this.repositorioEnfermera = repositorioEnfermera;
        }
        public IActionResult OnGet()
        {
            Enfermeras = repositorioEnfermera.GetAllEnfermera();

            if (Enfermeras == null)
                return RedirectToPage("Error");
            return Page();

=======
        {
            this.repositorioEnfermera = repositorioEnfermera;
        }
        public IActionResult OnGet()
        {
            Enfermeras = repositorioEnfermera.GetAllEnfermera();

            // if (Enfermeras == null)
            //     return RedirectToPage("Error");

            return Page();
>>>>>>> 6f25dcb528736312d41f49d14afc600fc7970168
        }
    }
}
