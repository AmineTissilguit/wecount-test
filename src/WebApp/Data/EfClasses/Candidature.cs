using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data.EfClasses
{
    [Table("CANDIDATURE")]
    public class Candidature
    {
        public Guid Id { get; set; }

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
        public DateTime CreatedOn { get; set; }

        [Required]
        public string NiveauEtude { get; set; }

        [Required]
        public int AnneeExperience { get; set; }

        [Required]
        public string DernierEmployeur { get; set; }

        [Required]
        public string CV { get; set; }
    }
}