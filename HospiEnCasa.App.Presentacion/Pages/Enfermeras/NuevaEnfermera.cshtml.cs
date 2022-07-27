using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
    public class NuevaEnfermeraModel : PageModel
    {
        [BindProperty]
        public Enfermera Enfermera { get; set; }

        public bool IsCreateEnfermera { get; set; }
        public ModalInfo ModalInfo { get; set; }

        private readonly IRepositorioEnfermera repositorioEnfermera;

        public NuevaEnfermeraModel(IRepositorioEnfermera repositorioEnfermera){
            this.repositorioEnfermera = repositorioEnfermera;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(){

            IsCreateEnfermera = false;

            if(!ModelState.IsValid)
                return Page();
            Enfermera nuevaEnfermera = repositorioEnfermera.AddEnfermera(Enfermera);
            if(nuevaEnfermera == null){
                return RedirectToPage("Error");
            }
            ModalInfo = new ModalInfo
            {
                TitleModal = "Nueva Enfermera",
                MsgModal = "Enfermera " + nuevaEnfermera.Nombres + " " + nuevaEnfermera.Apellidos + " creada correctamente",
                PageRedirect = "/Enfermeras/Enfermeras"
            };

            IsCreateEnfermera = true;
            
            return Page();
        }
    }
}
