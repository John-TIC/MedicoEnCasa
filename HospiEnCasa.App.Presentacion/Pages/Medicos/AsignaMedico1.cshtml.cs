using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;

namespace HospiEnCasa.App.Presentacion.Pages.Medicos
{
    public class AsignaMedico1Model : PageModel
    {
        [BindProperty]
        public Paciente Paciente { get; set; }

        [BindProperty]
        public Medico Medico {get; set;}
        public bool EstaAsignadoMedico { get; set; }

        public ModalInfo ModalInfo {get; set; }
        private readonly IRepositorioMedico repositorioMedico;
        private IRepositorioPaciente repositorioPaciente;
        public IEnumerable<Medico> Medicos { get; set; }

        public AsignaMedico1Model(IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioMedico = repositorioMedico;
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet(string filtroB, string criterio, int idPaciente)
        {
            Paciente = repositorioPaciente.GetPaciente(idPaciente);

            if (Paciente == null)
                return RedirectToPage("Error");

            ViewData["pacienteAAsignar"] = Paciente.Identificacion + " : " + Paciente.Nombres + " " + Paciente.Apellidos;

            Medicos = repositorioMedico.GetMedicosXFiltro(filtroB, criterio);

            if(Medicos == null || Medicos.Count() == 0)
                Medicos = null;

            return Page();
        }

        public IActionResult OnGetAsignarMedico(int idPaciente, int idMedico)
        {
            EstaAsignadoMedico = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (idMedico > 0)
            {
                Paciente = repositorioPaciente.GetPaciente(idPaciente);
                Paciente.MedicoId = idMedico;
                Paciente = repositorioPaciente.UpdatePaciente(Paciente);
            }

            ModalInfo = new ModalInfo{
                TitleModal = "Médico Asignado",
                MsgModal = "El Médico para el paciente " + Paciente.Nombres + " " + Paciente.Apellidos + " fue asignado correctamente",
                PageRedirect = "/Pacientes/Pacientes"
            };

            EstaAsignadoMedico = true;

            return Page();
        }

    }
}