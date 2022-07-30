using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HospiEnCasa.App.Presentacion.Model
{
    public class CargarAvatarEnDB
    {
        // [Required]
        [Display(Name="Avatar")]
        public IFormFile FormFile { get; set; }
    }
}