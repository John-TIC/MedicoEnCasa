using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
    public class FamiliarModel : PageModel
    {

        [BindProperty]
        public FamiliarDesignado FamiliarDesignado { get; set; }

        public bool IsUpdateFamiliar { get; set; }

        public ModalInfo ModalInfo { get; set; }

        [TempData]
        public int IdPaciente { get; set; }

        private readonly IRepositorioFamiliarDesignado repositorioFamiliar;
        private readonly IRepositorioPaciente repositorioPaciente;

        public FamiliarModel(IRepositorioFamiliarDesignado repositorioFamiliar, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int id)
        {
            Paciente paciente = repositorioPaciente.GetPaciente(id);
            IdPaciente = id;

            if (paciente == null)
                return RedirectToPage("Error");

            ViewData["pacienteACuidar"] = paciente.Identificacion + " : " + paciente.Nombres + " " + paciente.Apellidos;

            FamiliarDesignado = repositorioFamiliar.GetFamiliarDesignado((int)paciente.FamiliarDesignadoId);

            if (FamiliarDesignado == null)
                return RedirectToPage("Error");

            return Page();
        }
        //Actualizar Familiar
        public IActionResult OnPost()

        {
            IsUpdateFamiliar = false;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FamiliarDesignado.Id > 0)
            {
                FamiliarDesignado = repositorioFamiliar.UpdateFamiliarDesignado(FamiliarDesignado);
                if (FamiliarDesignado == null)
                    return RedirectToPage("Error");

                ModalInfo = new ModalInfo
                {
                    TitleModal = " Familiar Actualizado",
                    MsgModal = "Familiar " + FamiliarDesignado.Nombres + " " + FamiliarDesignado.Apellidos + " Actualizado correctamente",
                    PageRedirect = "/Familiares/Familiar"
                };

                IsUpdateFamiliar = true;

            }

            return Page();
        }

    }
}
