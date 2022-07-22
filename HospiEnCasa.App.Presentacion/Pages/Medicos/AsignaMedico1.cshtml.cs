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
        public int IdPaciente { get; set; }
        public bool EstaAsignadoMedico { get; set; }

        public ModalInfo ModalInfo {get; set; }
        private readonly IRepositorioMedico repositorioMedico;
        private IRepositorioPaciente repositorioPaciente;
        public IEnumerable<Medico> Medicos { get; set; }

        [TempData]
        public string Mensaje { get;set;}

        public AsignaMedico1Model(IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioMedico = repositorioMedico;
            this.repositorioPaciente = repositorioPaciente;
        }
        public IActionResult OnGet(string filtroB, string criterio, int idPaciente)
        {
            Paciente paciente = repositorioPaciente.GetPaciente(idPaciente);

            if (paciente == null)
                return RedirectToPage("Error");

            ViewData["pacienteAAsignar"] = paciente.Identificacion + " : " + paciente.Nombres + " " + paciente.Apellidos;
            IdPaciente = paciente.Id;

            Medicos = repositorioMedico.GetMedicosXFiltro(filtroB, criterio);

            if(Medicos == null || Medicos.Count() == 0)
                Medicos = null;

            return Page();
        }

        public IActionResult OnPut(int idPaciente)
        {
            EstaAsignadoMedico = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Medico.Id > 0)
            {
                Paciente paciente = repositorioPaciente.GetPaciente(idPaciente);
                paciente.MedicoId = Medico.Id;
                Paciente = repositorioPaciente.UpdatePaciente(paciente);
            }

            ModalInfo = new ModalInfo{
                TitleModal = "Médico Asignado",
                MsgModal = "El Médico " + Medico.Nombres + " " + Medico.Especialidad + " fue asignado correctamente",
                PageRedirect = "/Pacientes/Pacientes"
            };
            EstaAsignadoMedico = false;
            Mensaje = "El Médico fue asignado correctamente";
            return RedirectToPage("/Pacientes/Pacientes/Paciente");
        }

    }
}