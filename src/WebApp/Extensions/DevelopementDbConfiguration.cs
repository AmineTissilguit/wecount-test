using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApp.Data.EfClasses;
using WebApp.Data.EfCode;

namespace WebApp.Extensions
{
    public static class DevelopementDbConfiguration
    {
        public static IApplicationBuilder UseDevelopementDbSetup(this IApplicationBuilder app, AppDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();
            dbContext.AddRange(DevelopmentSeeder());
            dbContext.SaveChanges();


            return app;
        }

        private static List<Candidature> DevelopmentSeeder()
        {
            return new List<Candidature>()
        {
            new Candidature()
            {
                CV   = "/CV/test01.pdf",
                Mail = "Elmerdi@gmail.com",
                Nom  = "Hamid",
                Telephone = "065214418",
                Prenom = "Elmerdi",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
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
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Alae@gmail.com",
                Nom = "Alae",
                Telephone = "1234875",
                Prenom = "Alae",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Halima@gmail.com",
                Nom = "Halima",
                Telephone = "1234567",
                Prenom = "Halima",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Fatima@gmail.com",
                Nom = "Fatima",
                Telephone = "123456789",
                Prenom = "Fatima",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "David@gmail.com",
                Nom = "David",
                Telephone = "9875642",
                Prenom = "David",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "dddd@gmail.com",
                Nom = "Rahma",
                Telephone = "05298647",
                Prenom = "Rahma",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "/CV/test01.pdf",
                Mail = "Lotfi@gmail.com",
                Nom = "Lotfi",
                Telephone = "06998585",
                Prenom = "Lotfi",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            }
        };

        }
    }
}
