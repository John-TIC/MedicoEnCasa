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
    public class PacienteModel : PageModel
    {
        [BindProperty]
        public Paciente Paciente { get; set; }
        public bool IsUpdatePaciente { get; set; }
        public ModalInfo ModalInfo { get; set; }

        private readonly IRepositorioPaciente repositorioPaciente;

        public PacienteModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int id)
        {
            Paciente = repositorioPaciente.GetPaciente(id);

            if (Paciente == null)
                return RedirectToPage("Error");

            ViewData["idPaciente"] = id;

            return Page();
        }
        //Actualizar Paciente
        public IActionResult OnPost()

        {
            IsUpdatePaciente = false;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Paciente.Id > 0)
            {
                Paciente = repositorioPaciente.UpdatePaciente(Paciente);
                if (Paciente == null)
                    return RedirectToPage("Error");

                ModalInfo = new ModalInfo
                {
                    TitleModal = " Paciente Actualizado",
                    MsgModal = "Paciente " + Paciente.Nombres + " " + Paciente.Apellidos + " Actualizado correctamente",
                    PageRedirect = "/Pacientes/Paciente"
                };

                IsUpdatePaciente = true;

            }

            return Page();
        }

    }
}
