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
        [Required(ErrorMessage = "Le champ Nom est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prenom est obligatoire")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Mail est obligatoire")]
        [EmailAddress(ErrorMessage = "Mail n'est pas valide")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ Telephone est obligatoire")]
        [Phone]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le champ NiveauEtude est obligatoire")]
        public string NiveauEtude { get; set; }

        [Required(ErrorMessage = "Le champ AnneeExperience est obligatoire")]
        [Range(0,20,ErrorMessage = "Le champ AnneeExperience doit être compris entre 0 et 20")]
        public int AnneeExperience { get; set; }

        [Required(ErrorMessage = "Le champ DernierEmployeur est obligatoire")]
        public string DernierEmployeur { get; set; }

        [Required(ErrorMessage = "Le champ UploadedCV est obligatoire")]
        public IFormFile UploadedCV { get; set; }
    }
}
