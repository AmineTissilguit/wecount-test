using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UploadCVModel
    {
        public Guid CandidatureId { get; set; }

        [Required(ErrorMessage = "Veuillez télécharger votre CV")]
        [Display(Name = "Télécharger votre CV")]
        public IFormFile UploadedCV { get; set; }
    }
}
