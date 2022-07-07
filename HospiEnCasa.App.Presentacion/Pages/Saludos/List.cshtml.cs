using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class ListModel : PageModel
    {
        private string[] saludos = {"Buenos dias", "Buenas tardes", "Buenas noches", "Hasta mañana"};

        public List<string> ListaSaludos {get; set;}
        public void OnGet()
        {
            ListaSaludos = new List<string>();
            ListaSaludos.AddRange(saludos);
        }
    }
}
