using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
    public class NuevoMedicoModel : PageModel
    {
        [BindProperty]
        public Medico Medico { get; set; }

        public bool IsCreateMedico { get; set; }
        public ModalInfo ModalInfo { get; set; }

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
            IsCreateMedico = false;

            if (!ModelState.IsValid)
                return Page();

            Medico nuevoMedico = repositorioMedico.AddMedico(Medico);

            if (nuevoMedico == null)
            {
                return RedirectToPage("Error");
            }

            ModalInfo = new ModalInfo
            {
                TitleModal = "Nuevo Medico",
                MsgModal = "Medico " + nuevoMedico.Nombres + " " + nuevoMedico.Apellidos + " creado correctamente",
                PageRedirect = "/Medicos/Medicos"
            };

            IsCreateMedico = true;

            return Page();
        }
    }
}
