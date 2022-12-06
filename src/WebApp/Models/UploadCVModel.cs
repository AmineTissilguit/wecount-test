using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

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
