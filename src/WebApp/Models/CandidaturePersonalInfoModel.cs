using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CandidaturePersonalInfoModel
    {
        [Required(ErrorMessage = "Le champ Nom est obligatoire")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prenom est obligatoire")]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Mail est obligatoire")]
        [EmailAddress(ErrorMessage = "Mail n'est pas valide")]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ Telephone est obligatoire")]
        [Display(Name = "Telephone")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telephone n'est pas valide")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le champ NiveauEtude est obligatoire")]
        [Display(Name = "NiveauEtude")]
        public string NiveauEtude { get; set; }

        [Required(ErrorMessage = "Le champ AnneeExperience est obligatoire")]
        [Range(0, 20, ErrorMessage = "Le champ AnneeExperience doit être compris entre 0 et 20")]
        [Display(Name = "Annee Experience")]
        public int AnneeExperience { get; set; }

        [Required(ErrorMessage = "Le champ DernierEmployeur est obligatoire")]
        [Display(Name = "Dernier Employeur")]
        public string DernierEmployeur { get; set; }

    }
}
