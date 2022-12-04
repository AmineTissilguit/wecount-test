using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Data.EfClasses;
using WebApp.Data.EfCode;
using WebApp.Services;
using WebApp.Services.Intrefaces;

namespace WebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // register DbContext
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(_configuration.GetConnectionString("Path")));

            // register App Services
            services.AddScoped<ICandidaturesService, CandidaturesService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.Migrate();
                dbContext.Database.EnsureCreated();
                dbContext.AddRange(DevelopmentSeeder());
                dbContext.SaveChanges();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private List<Candidature> DevelopmentSeeder()
        {
            return new List<Candidature>()
        {
            new Candidature()
            {
                CV   = "dddd",
                Mail = "dddd@gmail.com",
                Nom  = "Hamid",
                Telephone = "44444444",
                Prenom = "KKK",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV   = "dddd",
                Mail = "dddd@gmail.com",
                Nom  = "Hamid",
                Telephone = "44444444",
                Prenom = "KKK",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
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
                CV = "dddd",
                Mail = "dddd@gmail.com",
                Nom = "Rahma",
                Telephone = "44444444",
                Prenom = "KKK",
                DernierEmployeur = "dddd",
                Id = Guid.NewGuid(),
                AnneeExperience = 4,
                NiveauEtude = "Bac+2"
            },
            new Candidature()
            {
                CV = "dddd",
                Mail = "dddd@gmail.com",
                Nom = "Hamid",
                Telephone = "06998585",
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
