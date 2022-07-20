using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Paciente> Pacientes { get; set; }

        private readonly IRepositorioPaciente repositorioPaciente;

        public IndexModel(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public void OnGet()
        {
        }

        // Actions for Map
        public IActionResult OnGetLocationsPacientes()
        {
            Pacientes = repositorioPaciente.GetAllPacientesAndHistoria();

            if (Pacientes == null || Pacientes.Count() == 0)
                return RedirectToPage();

            List<LocationPaciente> LocationPacientes = new List<LocationPaciente>();

            foreach (var paciente in Pacientes)
            {
                LocationPacientes.Add(new LocationPaciente
                {
                    FullName = paciente.Nombres + " " + paciente.Apellidos,
                    Diagnostico = paciente.Historia != null ? paciente.Historia.Diagnostico : "Diagnostico pendiente",
                    Latitud = (decimal)paciente.Latitud ,
                    Longitud = (decimal)paciente.Longitud,
                    IdPaciente = paciente.Id
                });
            }

            return new JsonResult(LocationPacientes);
        }
    }
}
