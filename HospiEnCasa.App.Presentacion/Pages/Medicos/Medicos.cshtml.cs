using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using Microsoft.AspNetCore.Authorization;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
    public class MedicosModel : PageModel
    {
        private readonly IRepositorioMedico repositorioMedico;
        public IEnumerable<Medico> Medicos { get; set; }

        public MedicosModel(IRepositorioMedico repositorioMedico)
        {
            this.repositorioMedico = repositorioMedico;
        }
        public IActionResult OnGet()
        {
            Medicos = repositorioMedico.GetAllMedicos();

            if(Medicos == null || Medicos.Count() == 0)
                Medicos = null;

            return Page();
        }
    }
}
