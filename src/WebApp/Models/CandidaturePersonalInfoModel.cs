using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class CandidaturePersonalInfoModel
    {
        [Required(ErrorMessage = "Le champ Nom est obligatoire")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ Prénom est obligatoire")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le champ Mail est obligatoire")]
        [EmailAddress(ErrorMessage = "Mail n'est pas valide")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ Téléphone est obligatoire")]
        [Display(Name = "Téléphone")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telephone n'est pas valide")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le champ Niveau d'étude est obligatoire")]
        [Display(Name = "Niveau d'étude")]
        public string NiveauEtude { get; set; }

        [Required(ErrorMessage = "Le champ Nombre d'annee d'expérience est obligatoire")]
        [Range(0, 20, ErrorMessage = "Le champ Nombre d'annee d'expérience doit être compris entre 0 et 20")]
        [Display(Name = "Nombre d'annee d'expérience")]
        public int AnneeExperience { get; set; }

        [Required(ErrorMessage = "Le champ Dernier employeur est obligatoire")]
        [Display(Name = "Dernier employeur")]
        public string DernierEmployeur { get; set; }

    }
}
