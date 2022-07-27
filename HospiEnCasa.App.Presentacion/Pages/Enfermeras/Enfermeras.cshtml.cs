using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
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

            if (Enfermeras == null || Enfermeras.Count() == 0)
                Enfermeras = null;

            return Page();
        }
    }
}
