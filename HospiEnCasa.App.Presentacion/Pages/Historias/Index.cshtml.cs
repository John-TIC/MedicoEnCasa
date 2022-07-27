using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages.Historias
{
    [Authorize]
    public class IndexModel : PageModel
    {

        public Paciente Paciente { get; set; }

        [BindProperty]
        public SugerenciaCuidado SugerenciaCuidado { get; set; }

        private readonly IMemoryCache cache;

        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioSugerenciaCuidado repositorioSugerenciaCuidado;

        public ModalInfo ModalInfo { get; set; }

        public IndexModel(IRepositorioPaciente repositorioPaciente, IRepositorioSugerenciaCuidado repositorioSugerenciaCuidado, IMemoryCache cache)
        {
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioSugerenciaCuidado = repositorioSugerenciaCuidado;
            this.cache = cache;
        }

        public IActionResult OnGet(int idPaciente)
        {
            Paciente = repositorioPaciente.GetHistoriaPaciente(idPaciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            cache.Set("pacienteFull", Paciente);

            return Page();
        }

        public IActionResult OnPost(int idPaciente)
        {
            Paciente = repositorioPaciente.GetHistoriaPaciente(idPaciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            if (!ModelState.IsValid)
                return Page();

            if (Paciente.Historia == null)
                return RedirectToPage("/Pacientes/Paciente", new { id = idPaciente });


            Paciente.Historia.Sugerencias.Add(SugerenciaCuidado);

            Paciente = repositorioPaciente.UpdatePaciente(Paciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            cache.Set("pacienteFull", Paciente);

            ModalInfo = new ModalInfo
            {
                TitleModal = "Nueva Sugerencia Cuidado",
                MsgModal = "Sugerencia del paciente " + Paciente.Nombres + " " + Paciente.Apellidos + " creada correctamente",
                PageRedirect = "/Historias/" + Paciente.HistoriaId.ToString()
            };

            ViewData["IsCreateSugerencia"] = true;

            return Page();
        }

        public IActionResult OnGetSugerenciaModal(int idPaciente, int idSugerencia)
        {
            if (idPaciente == 0)
                return RedirectToPage("/Pacientes/Pacientes");

            if (idSugerencia == 0)
                return RedirectToPage(idPaciente);

            SugerenciaCuidado = repositorioSugerenciaCuidado.GetSugerenciaCuidado(idSugerencia);
            return Partial("Historias/Shared/_EditModalSugerencia", SugerenciaCuidado);
        }

        public IActionResult OnPostUpdateSugerenciaModal(int idPaciente, int idSugerencia)
        {
            if (idPaciente == 0)
                return RedirectToPage("/Pacientes/Pacientes");

            if (idSugerencia == 0)
                return RedirectToPage(idPaciente);

            if (!ModelState.IsValid)
                return Page();

            SugerenciaCuidado.Id = idSugerencia;
            repositorioSugerenciaCuidado.UpdateSugerenciaCuidado(SugerenciaCuidado);

            return RedirectToPage(idPaciente);
        }
    }
}