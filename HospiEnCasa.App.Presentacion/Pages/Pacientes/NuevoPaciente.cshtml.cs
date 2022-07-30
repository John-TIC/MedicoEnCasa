using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Presentacion.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using HospiEnCasa.App.Presentacion.Utilities;

namespace HospiEnCasa.App.Presentacion.Pages
{
    [Authorize]
    public class NuevoPacienteModel : PageModel
    {

        [BindProperty]
        public Paciente Paciente { get; set; }

        [BindProperty]
        public Historia Historia {get; set;}

        [BindProperty]
        public SugerenciaCuidado SugerenciaCuidado {get; set;}

        [BindProperty]
        public CargarAvatarEnDB Avatar { get; set; }

        public bool IsCreatePaciente { get; set; }
        public ModalInfo ModalInfo {get; set; }

        private readonly IRepositorioPaciente repositorioPaciente;
        private readonly long fileSizeLimitAvatar;
        private readonly string[] permittedExtensionAvatar;

        public NuevoPacienteModel(IRepositorioPaciente repositorioPaciente, IConfiguration config)
        {
            this.repositorioPaciente = repositorioPaciente;
            this.fileSizeLimitAvatar = config.GetValue<long>("FileSizeLimitAvatar");
            this.permittedExtensionAvatar = config.GetSection("PermittedExtensionsAvatar").Get<string[]>();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            IsCreatePaciente = false;

            if (!ModelState.IsValid)
                return Page();

            if(Avatar.FormFile != null){
                byte[] formFileAvatar = await FileHelpers.ProcessFormFile<CargarAvatarEnDB>(Avatar.FormFile, ModelState, permittedExtensionAvatar, fileSizeLimitAvatar);

                if (!ModelState.IsValid)
                    return Page();

                Paciente.Avatar = formFileAvatar;
            }else{
                Paciente.Avatar = null;
            }

            Paciente.Historia = Historia;
            Historia.Sugerencias = new List<SugerenciaCuidado>{
                SugerenciaCuidado
            };

            Paciente nuevoPaciente = repositorioPaciente.AddPaciente(Paciente);

            if(nuevoPaciente == null)
                return RedirectToPage("Error");

            ModalInfo = new ModalInfo{
                TitleModal = "Nuevo Paciente",
                MsgModal = "Paciente " + nuevoPaciente.Nombres + " " + nuevoPaciente.Apellidos + " creado correctamente",
                PageRedirect = "/Pacientes/Pacientes"
            };

            IsCreatePaciente = true;

            return Page();
        }
    }
}
