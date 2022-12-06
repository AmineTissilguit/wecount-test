using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DetailModel
    {
        public string Nom { get; set; }

        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        public string Mail { get; set; }

        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }

        [Display(Name = "Niveau d'étude")]
        public string NiveauEtude { get; set; }
        
        [Display(Name = "Nombre d'annee d'expérience")]
        public int AnneeExperience { get; set; }
        
        [Display(Name = "Dernier employeur")]
        public string DernierEmployeur { get; set; }

        public string CV { get; set; }
    }
}
