using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data.EfClasses;
using WebApp.Data.EfCode;

namespace WebApp.Extensions
{
    public static class DevelopementDbConfiguration
    {
        public static IApplicationBuilder UseDevelopementDbSetup(this IApplicationBuilder app, AppDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Candidatures.Any())
            {
                dbContext.AddRange(DevelopmentSeeder());
                dbContext.SaveChanges();
            }

            return app;
        }

        private static List<Candidature> DevelopmentSeeder()
        {
            return new List<Candidature>()
        {
            new Candidature()
            {
                CV   = "/CV/amine-tissilguit-cv.pdf",
                Mail = "amine.tissilguit@gmail.com",
                Nom  = "TISSILGUIT",
                Telephone = "0698686638",
                Prenom = "Amine",
                DernierEmployeur = "Dataflex",
                Id = Guid.NewGuid(),
                AnneeExperience = 1,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test02.pdf",
                Mail = "Moad@gmail.com",
                Nom = "Moad",
                Telephone = "065242888",
                Prenom = "Moad",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "hiba@gmail.com",
                Nom = "hiba",
                Telephone = "0652481235",
                Prenom = "hiba",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Latifa@gmail.com",
                Nom = "Latifa",
                Telephone = "44444444",
                Prenom = "Latifa",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Manal@gmail.com",
                Nom = "Manal",
                Telephone = "0632145",
                Prenom = "KKK",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test02.pdf",
                Mail = "Hamza@gmail.com",
                Nom = "Hamza",
                Telephone = "0325647",
                Prenom = "Hamza",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Karim@gmail.com",
                Nom = "Karim",
                Telephone = "0325647",
                Prenom = "Karim",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test02.pdf",
                Mail = "Noah@gmail.com",
                Nom = "Noah",
                Telephone = "44444444",
                Prenom = "Noah",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test02.pdf",
                Mail = "sofian@gmail.com",
                Nom = "Sofian",
                Telephone = "44444444",
                Prenom = "Sofian",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Zakaria@gmail.com",
                Nom = "Zakaria",
                Telephone = "44444444",
                Prenom = "Zakaria",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test02.pdf",
                Mail = "dddd@gmail.com",
                Nom = "Hamid",
                Telephone = "44444444",
                Prenom = "KKK",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            }
        };

        }
    }
}
