using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
    public class AsignaMedicoModel : PageModel
    {
        [TempData]
        public int IdPaciente { get; set; }
        
        public Medico Medico;
        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly IRepositorioMedico repositorioMedico;

        public AsignaMedicoModel(IRepositorioMedico repositorioMedico, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioMedico = repositorioMedico;
            this.repositorioPaciente = repositorioPaciente;
        }  

        public IActionResult OnGet(int id)
        {
            Paciente paciente = repositorioPaciente.GetPaciente(id);

            if (paciente == null)
                return RedirectToPage("Error");

            ViewData["pacienteAAsignar"] = paciente.Identificacion + " : " + paciente.Nombres + " " + paciente.Apellidos;
            IdPaciente = paciente.Id;

            return Page();

        }

        public IActionResult OnPost(int medicoid)
        {
            if (medicoid != 0)
            {
                Medico medico = repositorioMedico.GetMedico(medicoid);
            }
            return Page();
/*            if (!ModelState.IsValid)
                return Page();

            FamiliarDesignado familiar = repositorioFamiliar.AddFamiliarDesignado(FamiliarDesignado);

            if (familiar == null)
                return RedirectToPage("Error");

            Paciente paciente = repositorioPaciente.GetPaciente(IdPaciente);
*/
        } 

        //public void OnGet()
        //{
        //}
        /*
        [BindProperty]
        public FamiliarDesignado FamiliarDesignado { get; set; }

        [TempData]
        public int IdPaciente { get; set; }

        public bool IsCreateFamiliar { get; set; }
        //public ModalInfo ModalInfo { get; set; }

        private readonly IRepositorioFamiliarDesignado repositorioFamiliar;
        private readonly IRepositorioPaciente repositorioPaciente;

        public AsignaMedicoModel(IRepositorioFamiliarDesignado repositorioFamiliar, IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioFamiliar = repositorioFamiliar;
            this.repositorioPaciente = repositorioPaciente;
        }  

        public IActionResult OnGet(int id)
        {
            Paciente paciente = repositorioPaciente.GetPaciente(id);

            if (paciente == null)
                return RedirectToPage("Error");

            ViewData["pacienteACuidar"] = paciente.Identificacion + " : " + paciente.Nombres + " " + paciente.Apellidos;
            IdPaciente = paciente.Id;

            return Page();

        }

        public IActionResult OnPost()
        {
            IsCreateFamiliar = false;

            if (!ModelState.IsValid)
                return Page();

            FamiliarDesignado familiar = repositorioFamiliar.AddFamiliarDesignado(FamiliarDesignado);

            if (familiar == null)
                return RedirectToPage("Error");

            Paciente paciente = repositorioPaciente.GetPaciente(IdPaciente);

            if (paciente == null)
                return RedirectToPage("Error");

            paciente.FamiliarDesignado = familiar;
            repositorioPaciente.UpdatePaciente(paciente);

         //   ModalInfo = new ModalInfo{
         //       TitleModal = "Nuevo Familiar",
         //       MsgModal = "Familiar del paciente " + paciente.Nombres + " " + paciente.Apellidos + " creado correctamente",
         //       PageRedirect = "/Pacientes/Pacientes"
         //   };  

        //    IsCreateFamiliar = true;

        //    return Page(); */
        //}

    }
}
