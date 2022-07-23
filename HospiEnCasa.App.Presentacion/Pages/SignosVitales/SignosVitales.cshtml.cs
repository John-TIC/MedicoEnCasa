using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;

namespace HospiEnCasa.App.Presentacion.Pages.SignosVitales
{
    public class SignosVitalesModel : PageModel
    {
        public Paciente Paciente {get; set;}

        [BindProperty]
        public SignoVital SignoVital { get; set; }

        private readonly IRepositorioPaciente repositorioPaciente;

        public bool IsCreateSignoVital { get; set; }
        public ModalInfo ModalInfo { get; set; }

        public SignosVitalesModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int idPaciente)
        {
            Paciente = repositorioPaciente.GetSignosVitalesPaciente(idPaciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            return Page();
        }

        public IActionResult OnPost(int idPaciente)
        {
            IsCreateSignoVital = false;

            Paciente = repositorioPaciente.GetSignosVitalesPaciente(idPaciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            if (!ModelState.IsValid)
                return Page();

            Paciente.SignosVitales.Add(SignoVital);

            Paciente = repositorioPaciente.UpdatePaciente(Paciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            ModalInfo = new ModalInfo
            {
                TitleModal = "Nuevo Signo Vital",
                MsgModal = "Signo vital del paciente " + Paciente.Nombres + " " + Paciente.Apellidos + " creado correctamente",
                PageRedirect = "/SignosVitales/" + SignoVital.Id.ToString()
            };

            IsCreateSignoVital = true;

            return Page();
        }
    }
}
