using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CandidatureForCreationModel
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [Phone]
        public string Telephone { get; set; }

        [Required]
        public string NiveauEtude { get; set; }

        [Required]
        public int AnneeExperience { get; set; }

        [Required]
        public string DernierEmployeur { get; set; }

        [Required]
        public IFormFile UploadedCV { get; set; }
    }
}
