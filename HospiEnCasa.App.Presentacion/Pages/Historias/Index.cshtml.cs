using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;

namespace HospiEnCasa.App.Presentacion.Pages.Historias
{
    public class IndexModel : PageModel
    {

        public Paciente Paciente { get; set; }

        [BindProperty]
        public SugerenciaCuidado NuevaSugerenciaCuidado { get; set; }

        private readonly IRepositorioPaciente repositorioPaciente;

        public bool IsCreateSugerencia { get; set; }
        public ModalInfo ModalInfo { get; set; }

        public IndexModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public IActionResult OnGet(int idPaciente)
        {
            Paciente = repositorioPaciente.GetHistoriaPaciente(idPaciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            return Page();
        }

        public IActionResult OnPost(int idPaciente)
        {
            IsCreateSugerencia = false;

            Paciente = repositorioPaciente.GetHistoriaPaciente(idPaciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            if (!ModelState.IsValid)
                return Page();

            Paciente.Historia.Sugerencias.Add(NuevaSugerenciaCuidado);

            Paciente = repositorioPaciente.UpdatePaciente(Paciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            ModalInfo = new ModalInfo
            {
                TitleModal = "Nueva Sugerencia Cuidado",
                MsgModal = "Sugerencia del paciente " + Paciente.Nombres + " " + Paciente.Apellidos + " creada correctamente",
                PageRedirect = "/Historias/" + Paciente.HistoriaId.ToString()
            };

            IsCreateSugerencia = true;

            return Page();
        }

    }
}