using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class NuevaEnfermeraModel : PageModel
    {
        [BindProperty]
        public Enfermera Enfermera { get; set; }

        private readonly IRepositorioEnfermera repositorioEnfermera;

        public NuevaEnfermeraModel(IRepositorioEnfermera repositorioEnfermera){
            this.repositorioEnfermera = repositorioEnfermera;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(){
            if(!ModelState.IsValid)
                return Page();
            
            Enfermera nuevaEnfermera = repositorioEnfermera.AddEnfermera(Enfermera);
        
            if(nuevaEnfermera == null){
                return RedirectToPage("Error");
            }
            return Page();
        }
    }
}
